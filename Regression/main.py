from models.bacteria import Bacteria
from business_logic.bacteria_reader import BacteriaReader

# Hent bakterierne ind
reader = BacteriaReader("bacteria.csv")
bacterias = reader.read_from_csv()

# Eksempel på hvordan vi kan hente alle baktierer der har en bestemt slægt eller klasse.
candidatus_microthrix_bacterias = bacterias.get_bacterias_by_genus("Candidatus_Microthrix")
print('Bakterier med slægten Candidatus Microthrix')
print(', '.join([x.get_asv() for x in candidatus_microthrix_bacterias]))

print('')

erysipelotrichia_bacterias = bacterias.get_bacterias_by_class("Erysipelotrichia")
print('Bakterier med klassen Erysipelotrichia')
print(', '.join([x.get_asv() for x in erysipelotrichia_bacterias]))


# Eksempel på hvordan data kan vises
import matplotlib.pyplot as plt

def example_plot():
    bacteria = bacterias.get_bacteria_by_asv("ASV2")
    plt.figure(0).canvas.set_window_title(bacteria)
    plt.xlabel('Measurement number')
    plt.ylabel('Bacteria concentration')
    for i in range(len(bacteria.get_measurements())):
        plt.plot(i, bacteria.get_measurement(i), 'rs')
    plt.show()

example_plot()