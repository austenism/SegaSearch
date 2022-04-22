import requests
from bs4 import BeautifulSoup

# makes comma separated list of values, contains year, title, genre, developer, and system
# if a cell previously contained a comma, it is replaced with a semicolon so that the csv doesnt get ruined

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
                    if(int(info[0][0:-1]) >= 2000):
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
