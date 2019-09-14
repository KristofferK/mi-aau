import csv
from models.bacteria import Bacteria
from business_logic.bacteria_browser import BacteriaBrowser

class BacteriaReader:
    def __init__(self, path: str):
        self.path = path
    
    def read_from_csv(self) -> BacteriaBrowser:
        with open(self.path) as csv_file:
            browser = BacteriaBrowser()
            csv_reader = csv.reader(csv_file, delimiter=',')
            line_count = 0

            for row in csv_reader:
                line_count += 1
                if (line_count == 1):
                    continue
                bacteria = Bacteria(row[0], row[1][3:], row[2][3:])
                bacteria.set_measurements(row[3:])
                browser.add(bacteria)
                
            return browser