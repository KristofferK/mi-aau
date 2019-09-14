from models.bacteria import Bacteria
from business_logic.bacteria_reader import BacteriaReader

reader = BacteriaReader("bacteria.csv")
bacterias = reader.read_from_csv()

candidatus_microthrix_bacterias = bacterias.get_bacterias_by_genus("Candidatus_Microthrix")
print('Bakterier med slægten Candidatus Microthrix')
print(', '.join([x.get_asv() for x in candidatus_microthrix_bacterias]))

print('')

erysipelotrichia_bacterias = bacterias.get_bacterias_by_class("Erysipelotrichia")
print('Bakterier med klassen Erysipelotrichia')
print(', '.join([x.get_asv() for x in erysipelotrichia_bacterias]))

