import requests
from bs4 import BeautifulSoup

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
for num in range(0, 9):
    offsets.append(0)
    info.append('')
yearoffset = 0
titleoffset = 0
genreoffset = 0
developeroffset = 0
systemsoffset = 0
sourcesoffset = 0

year = 0
title = ""
genre = ""
developer = ""
system = ""
state = 0

f = open('listofgames.csv', 'w')

for data in table.find_all(['td', 'th']):
    while True:
        if offsets[state] == 0:
            if state < 5:
                info[state] = data.text
            elif state == 5:
                for word in range(0,5):
                    info[word] = info[word].replace(',', ';')
                try:
                    f.write(
                        info[0][0:-1] + ", " + info[1][0:-1] + ", " + info[2][0:-1] + ", " + info[3][0:-1] + ", " + info[4][0:-1] + "\n")
                except:
                    state = state

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
