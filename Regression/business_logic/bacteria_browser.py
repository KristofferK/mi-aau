from typing import List
from models.bacteria import Bacteria

class BacteriaBrowser:
    bacterias: List[Bacteria] = []

    def __init__(self):
        pass

    def add(self, bacteria: Bacteria) -> None:
        self.bacterias.append(bacteria)

    def get(self, index: int) -> Bacteria:
        return self.bacterias[index]

    def get_bacteria_by_asv(self, asv: str) -> Bacteria:
        return next(b for b in self.bacterias if b.get_asv() == asv)
    
    def get_all(self) -> List[Bacteria]:
        return self.bacterias
    
    def get_bacterias_by_genus(self, genus: str) -> List[Bacteria]:
        return [b for b in self.bacterias if b.get_genus() == genus]
    
    def get_bacterias_by_class(self, bacteria_class: str) -> List[Bacteria]:
        return [b for b in self.bacterias if b.get_class() == bacteria_class]