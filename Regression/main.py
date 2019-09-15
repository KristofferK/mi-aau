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

example_plot()