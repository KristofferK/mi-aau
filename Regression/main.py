import os
import multiprocessing
import matplotlib.pyplot as plt
from models.bacterium import Bacterium
from business_logic.bacteria_browser import BacteriaBrowser
from business_logic.bacteria_reader import BacteriaReader

def main():
    # Hent bakterierne ind
    reader = BacteriaReader("bacteria.csv")
    bacteria = reader.read_from_csv()
    bacterium = bacteria.get_bacteria_by_asv("ASV1")
    print(bacterium.get_genus())
    print(bacterium.get_measurements())

    bacterium.get_asv()

    #example_browse(bacteria)
    #example_plot(bacteria)
    save_bacteria_images(bacteria)
    #save_bacteria_dat(bacteria)
    train_test_split(bacteria)


# Eksempel på hvordan vi kan hente alle baktierer der har en bestemt slægt eller klasse.
def example_browse(bacteria: BacteriaBrowser):
    candidatus_microthrix_bacteria = bacteria.get_bacteria_by_genus("Candidatus_Microthrix")
    print('Bakterier med slægten Candidatus Microthrix')
    print(', '.join([x.get_asv() for x in candidatus_microthrix_bacteria]))

    print('')

    erysipelotrichia_bacteria = bacteria.get_bacteria_by_class("Erysipelotrichia")
    print('Bakterier med klassen Erysipelotrichia')
    print(', '.join([x.get_asv() for x in erysipelotrichia_bacteria]))


# Eksempel på hvordan data kan vises
def example_plot(bacteria: BacteriaBrowser):
    bacterium = bacteria.get_bacteria_by_asv("ASV2")
    plt.figure(0).canvas.set_window_title(bacterium)
    plt.xlabel('Measurement number')
    plt.ylabel('Bacteria concentration')
    for i in range(len(bacterium.get_measurements())):
        plt.plot(i, bacterium.get_measurement(i), 'rs')
    plt.show()


# Hent alle bakterier ned og gem dem som billede
def print_image(bacterium):
    path = "bacteria_plots/%s.png" %(bacterium.get_asv())
    if os.path.isfile(path):
        print("skipped %s" %(path))
        return
    fig = plt.figure()
    plt.xlabel('Measurement number')
    plt.ylabel('Bacteria concentration')
    for i in range(len(bacterium.get_measurements())):
        plt.plot(i, bacterium.get_measurement(i), 'rs')
    fig.savefig(path)
    plt.close(fig)
    print("saved %s" %(path))

def save_bacteria_images(bacteria: BacteriaBrowser):
    if not os.path.exists("bacteria_plots"):
        os.mkdir("bacteria_plots")
    pool = multiprocessing.Pool()
    pool.map(print_image, bacteria.get_all())

# Hent alle baktierer ned  og gem dem som dat filer
def generate_dat(bacterium):
    path = "bacteria_dat/%s_complete.dat" %(bacterium.get_asv())
    path_train = "bacteria_dat/%s_train.dat" %(bacterium.get_asv())
    path_test = "bacteria_dat/%s_test.dat" %(bacterium.get_asv())
    if os.path.isfile(path):
        print("skipped %s" %(path))
        return
    
    with open(path, 'w') as file:
        with open(path_train, 'w') as file_train:
            with open(path_test, 'w') as file_test:
                contentComplete = ""
                contentTrain = ""
                contentTest = ""
                length = len(bacterium.get_measurements())
                for i in range(length):
                    contentComplete = contentComplete + str(i) + " " + str(bacterium.get_measurement(i)) + "\n"
                    if i >= length - 2:
                        contentTest = contentTest + str(i) + " " + str(bacterium.get_measurement(i)) + "\n"
                    else:
                        contentTrain = contentTrain + str(i) + " " + str(bacterium.get_measurement(i)) + "\n"
                file.write(contentComplete.strip())
                file_train.write(contentTrain.strip())
                file_test.write(contentTest.strip())
    print("saved %s" %(path))

def save_bacteria_dat(bacteria: BacteriaBrowser):
    if not os.path.exists("bacteria_dat"):
        os.mkdir("bacteria_dat")
    pool = multiprocessing.Pool()
    pool.map(generate_dat, bacteria.get_all()[0:20])


def train_test_split(bacteria: BacteriaBrowser):
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
    #diabetes_y_pred = regressor.predict(diabetes_X_test)

if __name__=='__main__':
    main()