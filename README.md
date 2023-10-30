# Phototelectric-Simulator

This project is based on a quantum physics phenomenon called the Photoelectric Effect.I created a simulation to visually represent what happens when light of a certain frequency hits surfaces of various materials. In the photoelectric effect, electrons are emitted from a material when light hits its surface as it provides energy to be released. However, the electron could only be emitted if it receives enough energy, which is referred to as the work function of the material. The photoelectric effect also relies on the intensity of the light that is hitting the material. The higher the intensity of the light hitting the material, the more electrons are released due to the one-to-one interaction between photons and electrons meaning more photons more electrons are released. Different material have different work functions meaning the electrons on their surface will require different amount of energies to be released, therefore all material will have a different threshold frequency where for electrons to be released the frequency of the light has to be greater than the threshold frequency for any electron to be released. The remaining energy left from removing the electron is converted to kinetic energy. Electrons will have various kinetic energies depending on how deep they are.

<img width="1332" alt="Screenshot 2023-10-30 at 22 59 58" src="https://github.com/angelorosu/Phototelectric-Simulator/assets/83517901/5b497018-b104-4038-8ab6-7dc9ce00aacd">




## Architecture Overview 
#### Model-View-ViewModel


MVVM is a software architectural pattern. It facilitates the separation of the user interface from the back-end logic. MVVM stands for Model-View-View Model where the code is split into 3 layers. The model is where the back-end logic is carried out. The View which provides the user interface and the View Model which separates the UI form the model.

This helped with my project as it made the code more maintainable and far easier to add in any new features if needed. Learning MVVM took some time but allowed me to add features a lot easier without as many complications. 

<img width="483" alt="mvvmarchitecture" src="https://github.com/angelorosu/Phototelectric-Simulator/assets/83517901/e29847ee-7f08-4f28-bffe-944c9cdc6ed3"> \

if user == wants to know more about mvvm: \
  keep reading \
else: \
  good bye! and thanks for reading ! \
\
\
\
\
The Model \
\
The first layer in MVVM is the Model layer. The model represents the actual data/ information that we are dealing with. An example of a model in my project will be the way I represent an electron, the electron will have an X-Coordinate, Y-Coordinate and a diameter. The model is not responsible for formatting text to look pretty on screen, it may sometimes be in a separate class which fetches data from a server. That class where the data will be fetched will act on the actual model.
Therefore, to correctly implement MVVM my model must not directly make data accessible to the UI or use data from it. The mode should only expose information to the view models.   

View Models \
\
The second layer of MVVM would be the View Model, where most of the code to implement it into the program using the MVVM architecture. The View Models should be used as pass throughs, where information is passed between the model and the UI. This is advantageous as it makes the data from the model directly available to the View independent of the technology used to create a UI.
The View Model would also expose methods, command and other points that would manipulate the model as the result of actions on the view and trigger events in the view.

The View \
\
The View is the last layer of the MVVM architecture and it’s the layer that is presented to the user. The view has the job of abstraction. It does this by simply displaying what the user needs by abstracting the model. For example, a date might be stored as seconds since January 1,1970, however a user would be displayed with date in the day/month/year display in their time zone.
In my project the view must present all the information to the user from the model in an understandable format and it must also allow for user to interact with the program.

