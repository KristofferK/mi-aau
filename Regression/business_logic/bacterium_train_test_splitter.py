from models.bacterium import Bacterium
from models.bacterium_train_test_split_result import BacteriumTrainTestSplitResult

class BacteriumTrainTestSplitter:
    def __init__(self, bacterium: Bacterium):
        self.set_bacterium(bacterium)
    
    def get_bacterium(self) -> Bacterium:
        return self.bacterium
    
    def set_bacterium(self, bacterium: Bacterium) -> None:
        self.bacterium = bacterium
    
    def split(self, train_size_percent: float) -> BacteriumTrainTestSplitResult:
        measurements = self.bacterium.get_measurements()
        train_size = int(len(measurements) * train_size_percent)
        
        result = BacteriumTrainTestSplitResult()
        result.x_train = list(range(0, train_size))
        result.y_train = measurements[:train_size]

        result.x_test = list(range(train_size, len(measurements)))
        result.y_test = measurements[train_size:]
        
        return result