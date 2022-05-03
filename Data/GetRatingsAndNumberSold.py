import requests
from bs4 import BeautifulSoup
from urllib import parse
from slugify import slugify


def getConsoleString(platform, state):
    if state == 1:
        if 'Dre' in platform:
            return 'DC'
        elif ' Boy ' in platform:
            return 'GB' + str(platform).split(' ')[2][0]
        elif 'Gear' in platform:
            return 'GG'
        elif 'ube' in platform:
            return 'GC'
        elif 'Genesis' in platform:
            return 'GEN'
        elif 'Windows' in platform:
            return 'PC'
        elif 'NeoGeo' in platform:
            return 'NG'
        elif 'DS' in platform:
            return str.split(platform, ' ')[1]
        elif 'Switch' in platform:
            return 'NS'
        elif 'Playstation' in platform:
            return 'PS' + str(platform).split(' ')[1][0]
        elif 'Wii' in platform:
            return str.replace(platform, ' ', '')
        elif 'Wonder' in platform:
            return 'WS'
        elif 'Series' in platform:
            return 'XS'
        elif '360' in platform:
            return 'X360'
        elif 'One' in platform:
            return 'XOne'
        elif 'Xbox' in platform:
            return 'XB'
        else:
            return 'N/A'
    elif state == 2:
        if 'Dre' in platform:
            return 'dreamcast'
        elif ' Boy ' in platform:
            return slugify(platform)
        elif 'ube' in platform:
            return slugify(platform)
        elif 'Windows' in platform:
            return 'PC'
        elif 'DS' in platform:
            return str.split(platform, ' ')[1]
        elif 'Switch' in platform:
            return 'Switch'
        elif 'Portable' in platform:
            return 'psp'
        elif 'Playstation' in platform:
            return slugify(platform)
        elif 'Wii' in platform:
            return slugify(platform)
        elif 'Xbox' in platform:
            return slugify(platform)
        elif 'Stadia' in platform:
            return platform
        else:
            return 'N/A'


def GetNumSold(Name, Platform):
    try:
        GameString = parse.quote_plus(Name)
        ConsoleString = getConsoleString(Platform, 1)
        if ConsoleString == 'N/A':
            return 0
        SearchUrl = 'https://www.vgchartz.com/games/games.php?name=' + GameString + '&console=' + ConsoleString
        page = BeautifulSoup(requests.get(SearchUrl).text, 'html.parser')

        attrs = {
            'id': 'generalBody'
        }
        GameUrl = 'None'
        table = page.find('div', attrs)
        for tr in table.find_all('tr'):
            try:
                temp = tr['style']
                GameNumber = str(tr.find('a')['href']).split('?')[1].split('®')[0].split('=')[1]
                GameUrl = 'https://www.vgchartz.com/game/' + GameNumber + '/e/sales/'
                break
            except:
                continue

        if GameUrl == 'None':
            return 0

        soup = BeautifulSoup(requests.get(GameUrl).text, 'html.parser')

        for link in soup.find_all('a'):
            try:
                if 'sales' in str.split(link['href'], '/')[-1]:
                    soup = BeautifulSoup(requests.get(link['href']).text, 'html.parser')
                    break
            except:
                continue

        attrs = {
            'id': 'gameSalesBox'
        }

        for text in soup.find_all('div', attrs):
            try:
                table = BeautifulSoup(str(text), 'html.parser')

                for words in table.find_all('td'):
                    if 'Total' in words.text and not 'Total Sales' in words.text:
                        return int(float(str(words.text[2:-7])) * 10000)
            except:
                continue
        return 0
    except:
        return 0


def GetRating(Name, Platform):
    GameString = slugify(Name)
    ConsoleString = getConsoleString(Platform, 2)
    if ConsoleString == 'N/A':
        return 0

    Url = 'https://www.metacritic.com/game/' + ConsoleString + '/' + GameString
    attrs = {
        'itemprop': 'ratingValue'
    }

    try:
        s = requests.Session()
        s.headers['User-Agent'] = 'Scraper'
        text = s.get(Url)
        soup = BeautifulSoup(text.text, 'html.parser')
        return int(soup.find('span', attrs).text)
    except:
        return 0
