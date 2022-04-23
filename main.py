import string

import requests
from bs4 import BeautifulSoup
import pyodbc


def checkwikiforseries(url):
    #print("querying " + url)
    individualpage = requests.get(url).text
    pagesoup = BeautifulSoup(individualpage, 'html.parser')
    pageattrs = {
        'class': 'infobox hproduct'
    }
    intext = pagesoup.find('table', pageattrs)
    intable = BeautifulSoup(str(intext), 'html.parser')

    flag = False

    for indata in intable.find_all(['td', 'th']):
        if flag:
            return indata.text
        if indata.text == 'Series':
            flag = True

    for indata in intable.find_all(['td', 'th']):
        if flag:
            return indata.text
        if indata.text == 'Parent series' or indata.text == 'Parent Series':
            flag = True

    return '-1'


username = "" #YOUR USERNAME
password = "" #YOUR PASSWORD

connection = pyodbc.connect(
    'DRIVER={ODBC Driver 17 for SQL Server};SERVER=mssql.cs.ksu.edu;DATABASE=cis560_team19;UID=' + username + ';PWD=' + password)
cur = connection.cursor()

URL = "https://en.wikipedia.org/wiki/List_of_Sega_video_games"
page = requests.get(URL).text
soup = BeautifulSoup(page, 'html.parser')
attrs = {
    'class': 'wikitable'
}
text = soup.find('table', attrs)
table = BeautifulSoup(str(text), 'html.parser')

offsets = []
info = []
Franchises = []
Genres = []
Teams = []

for num in range(0, 9):
    offsets.append(0)
    info.append('')

state = 0

f = open('listofgames.csv', 'w')


def sqlwrite(rowinfo):
    # year, title, genre(s), team(s), platform, franchise
    curgenrelist = {}
    curteamlist = {}

    for genre in rowinfo[2].split(';'):
        if genre not in Genres:
            Genres.append(genre)
            cur.execute("insert Sega.Genre(Name) values (N'" + genre.replace("'", "''") + "')")
        cur.execute("select GenreID from Sega.Genre where Name = N'" + genre.replace("'", "''") + "'")
        temp = {genre: str(cur.fetchone()).replace(', )', '').replace('(', '')}
        curgenrelist = {**temp, **curgenrelist}

    for team in rowinfo[3].split(';'):
        if team not in Teams:
            Teams.append(team)
            cur.execute("insert Sega.DevelopmentTeam(Name) values (N'" + team.replace("'", "''") + "')")
        cur.execute("select TeamID from Sega.DevelopmentTeam where Name = N'" + team.replace("'", "''") + "'")
        temp = {team: str(cur.fetchone()).replace(', )', '').replace('(', '')}
        curteamlist = {**temp, **curteamlist}

    cur.execute("select PlatformID from Sega.Platform where Name = N'" + rowinfo[4] + "'")
    PlatformID = str(cur.fetchone()).replace(', )', '').replace('(', '')

    if rowinfo[5] not in Franchises:
        Franchises.append(rowinfo[5].replace(';', ','))
        cur.execute("insert Sega.Franchise(Name) values (N'" + rowinfo[5].replace(';', ',').replace("'", "''") + "')")

    cur.execute("select FranchiseID from Sega.Franchise where Name = N'" + rowinfo[5].replace("'", "''") + "'")
    FranchiseID = str(cur.fetchone()).replace(', )', '').replace('(', '')

    mergeclause = "merge Sega.Game G using "
    selectclause = "(select Name, FranchiseID from (values (N'" + rowinfo[1].replace(';', ', ').replace("'", "''") + "', N'" + FranchiseID + "'))M(Name, FranchiseID)) Edits(Name, FranchiseID)"
    onclause = "on G.Name = Edits.Name "
    whenmatched = "when matched then update set FranchiseID = Edits.FranchiseID "
    whennotmatched = "when not matched then insert(Name, FranchiseID) values (Edits.Name, Edits.FranchiseID);"

    cur.execute(mergeclause + selectclause + onclause + whenmatched + whennotmatched)

    cur.execute("select GameID from Sega.Game where Name = N'" + rowinfo[1].replace(';', ', ').replace("'", "''") + "'")
    GameID = str(cur.fetchone()).replace(', )', '').replace('(', '')

    cur.execute("insert Sega.GamePlatform (GameID, PlatformID, ReleaseDate) values (" + GameID + ", " + PlatformID + ", '" + rowinfo[0] + "')") # THIS NEEDS RATING AT SOME POINT

    for GenreID in curgenrelist:
        cur.execute("insert Sega.GameGenre(GameID, GenreID) values(" + GameID + ", " + curgenrelist[GenreID] + ")")
    for TeamID in curteamlist:
        cur.execute("insert Sega.GameTeam(GameID, TeamID) values(" + GameID + ", " + curteamlist[TeamID] + ")")

    cur.commit()
    return


for data in table.find_all(['td', 'th']):
    while True:
        if offsets[state] == 0:
            if state < 5:
                info[state] = data.text[0:-1]
                if state == 1:
                    try:
                        info[6] = "https://en.wikipedia.org" + data.find('a')['href']
                    except:
                        info[5] = info[1]
                        info[6] = ''
            elif state == 5:
                if '20' in info[0]:
                    if info[6] != '':
                        info[5] = checkwikiforseries(info[6])
                        info[6] = ''
                        if info[5] == '-1':
                            info[5] = info[1]

                    for word in range(0, 6):
                        info[word] = info[word].replace(', ', ';').replace('"', '|')

                    # write to sql server
                    sqlwrite(info)
                    # try:
                    #     f.write(
                    #         info[0] + ", " + info[1] + ", " + info[2] + ", " + info[3] + ", " +
                    #         info[4] + ", " + info[5] + "\n")
                    # except:
                    #     state = state

            if 'rowspan' in str(data):
                rowspan = data.get('rowspan')
                if rowspan == '':
                    offsets[state] = 0
                else:
                    offsets[state] = int(rowspan) - 1
            state = (state + 1) % 9
            break
        else:
            offsets[state] -= 1
            state = (state + 1) % 9

f.close()
