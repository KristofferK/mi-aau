from models.bacterium import Bacterium
from business_logic.bacteria_reader import BacteriaReader

# Hent bakterierne ind
reader = BacteriaReader("bacteria.csv")
bacteria = reader.read_from_csv()

# Eksempel på hvordan vi kan hente alle baktierer der har en bestemt slægt eller klasse.
candidatus_microthrix_bacteria = bacteria.get_bacteria_by_genus("Candidatus_Microthrix")
print('Bakterier med slægten Candidatus Microthrix')
print(', '.join([x.get_asv() for x in candidatus_microthrix_bacteria]))

print('')

erysipelotrichia_bacteria = bacteria.get_bacteria_by_class("Erysipelotrichia")
print('Bakterier med klassen Erysipelotrichia')
print(', '.join([x.get_asv() for x in erysipelotrichia_bacteria]))


# Eksempel på hvordan data kan vises
import matplotlib.pyplot as plt

def example_plot():
    bacterium = bacteria.get_bacteria_by_asv("ASV2")
    plt.figure(0).canvas.set_window_title(bacterium)
    plt.xlabel('Measurement number')
    plt.ylabel('Bacteria concentration')
    for i in range(len(bacterium.get_measurements())):
        plt.plot(i, bacterium.get_measurement(i), 'rs')
    plt.show()
#example_plot()


# Eksempel på hvad vi kan træne med, og hvad vi kan teste imod
from business_logic.bacterium_train_test_splitter import BacteriumTrainTestSplitter
bacterium = bacteria.get_bacteria_by_asv("ASV1")
split_result = BacteriumTrainTestSplitter(bacterium).split(0.8)
print('Skal træne med følgende x værdier (måling nummer)')
print(split_result.x_train)
print('Skal træne med følgende y værdier (bakterie koncentration)')
print(split_result.y_train)
print('Skal teste mod disse x værdier (måling nummer)')
print(split_result.x_test)
print('Skal ramme disse y værdier (koncentration)')
print(split_result.y_test)

#from sklearn.linear_model import LinearRegression
#regressor = LinearRegression()  
#regressor.fit(split_result.x_train, split_result.y_train)