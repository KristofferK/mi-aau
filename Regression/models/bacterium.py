from typing import List

class Bacterium:
    measurements: List[float] = []

    def __init__(self, asv: str, genus: str, bacterium_class: str):
        self.genus = genus
        self.bacterium_class = bacterium_class
        self.asv = asv

    def get_asv(self) -> str:
        return self.asv 

    def get_genus(self) -> str:
        return self.genus

    def get_class(self) -> str:
        return self.bacterium_class

    def add_measurement(self, value: float) -> None:
        self.measurements.append(float(value))
    
    def get_measurement(self, index: int) -> float:
        return self.measurements[index]

    def set_measurements(self, measurements: List[float]) -> None:
        self.measurements = [float(m) for m in measurements]

    def get_measurements(self) -> List[float]:
        return self.measurements

    def __str__(self) -> str:
        return "Bacterium %s (genus %s of class %s)" %(self.asv, self.genus, self.bacterium_class)
