from typing import List

class Bacteria:
    measurements: List[float] = []

    def __init__(self, asv: str, genus: str, bacteria_class: str):
        self.genus = genus
        self.bacteria_class = bacteria_class
        self.asv = asv

    def get_asv(self) -> str:
        return self.asv 

    def get_genus(self) -> str:
        return self.genus

    def get_class(self) -> str:
        return self.bacteria_class

    def add_measurement(self, value: float) -> None:
        self.measurements.append(value)
    
    def get_measurement(self, index: int) -> float:
        return self.measurements[index]

    def set_measurements(self, measurements: List[float]) -> None:
        self.measurements = measurements

    def get_measurements(self) -> List[float]:
        return self.measurements

    def __str__(self) -> str:
        return "%s (%s)" %(self.genus, self.bacteria_class)
