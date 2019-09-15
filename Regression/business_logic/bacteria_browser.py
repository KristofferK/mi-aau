from typing import List
from models.bacterium import Bacterium

class BacteriaBrowser:
    bacteria: List[Bacterium] = []

    def __init__(self):
        pass

    def add(self, bacterium: Bacterium) -> None:
        self.bacteria.append(bacterium)

    def get(self, index: int) -> Bacterium:
        return self.bacteria[index]

    def get_bacteria_by_asv(self, asv: str) -> Bacterium:
        return next(b for b in self.bacteria if b.get_asv() == asv)
    
    def get_all(self) -> List[Bacterium]:
        return self.bacteria
    
    def get_bacteria_by_genus(self, genus: str) -> List[Bacterium]:
        return [b for b in self.bacteria if b.get_genus() == genus]
    
    def get_bacteria_by_class(self, bacterium_class: str) -> List[Bacterium]:
        return [b for b in self.bacteria if b.get_class() == bacterium_class]
