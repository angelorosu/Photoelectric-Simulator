using Photoelectric.DatabaseTestingç;
using Photoelectric.Electrons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Photoelectric
{
    public partial class MainWindow : Window
    {
        List<Ball> theBalls = new List<Ball>();
        List<Wall> theWalls = new List<Wall>();
        private static Random myRand = new Random();
        private DispatcherTimer theTimer;
        private bool canMove = true, stepping = false;
        private bool creatingBalls;
        double createDiameter = 0;
        Quanta quantaValues = new Quanta();


        public MainWindow()
        {
            InitializeComponent();
            //createWalls();
            Ball.Charge = .1;
            theTimer = new DispatcherTimer();
            theTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            theTimer.Tick += new EventHandler(TimerEvent);
            theTimer.Start();

        }

        private void TimerEvent(object sender, EventArgs e)
        {
            double tresholdWavelength;
            tresholdWavelength = Maths.ThresholdWavelength();

            //   if ((WavelengthSlider.Value<tresholdWavelength))


            if (canMove)
            {

                foreach (Ball theBall in theBalls)
                {
                    theBall.Move();

                }

                if ((WavelengthSlider.Value < tresholdWavelength) && LightInSlider.Value != 0 && metalSelection != null && WavelengthSlider.Value != 0)
                {
                    GenerateElectrons();


                }
                RemoveElectrons();
                ElectronPotential();
                Render();

            }
        }

        private void RemoveElectrons()
        {
            foreach (Ball theBall in theBalls)
            {
                if (theBall.XPos > (ElectronCanvas.Width - 10) || theBall.XVel < 1)
                {
                  //  theBalls.Remove(theBall);
                    theBall.XPos = 1241234;
                }
                if (theBall.XPos < 0)
                {
                 //   theBalls.Remove(theBall);
                  theBall.XPos = 1241234;
                }
            }
        }

        private void ElectronPotential()
        {
            if (!(ElectronCanvas == null))
            {
                Ball.Charge = Convert.ToInt32(BatteryVoltage.Value)/ 5 ;
                // GravityLabel.Content = Ball.Gravity;
            }
        }

        private void GenerateElectrons()
        {
            double tresholdWavelength;
            tresholdWavelength = Maths.ThresholdWavelength();


            if (!creatingBalls)
            {
                int newBalls = 1; // probability function of electrons being relesased placed in here
                                  // newBalls = newBalls * 1;
                if (newBalls > 0)
                {
                    for (int count = 0; count < newBalls; count++)
                    {
                        double diameter = myRand.Next(40) + 10 + createDiameter;
                        double XPos = -20;
                        double YPos = myRand.Next(150);
                        if (XPos < 0 + (diameter / 2))
                        {
                            XPos = XPos + diameter;
                        }
                        if (XPos > 500 - diameter)
                        {
                            XPos = XPos - diameter;
                        }
                        if (YPos < 0 + diameter)
                        {
                            YPos = YPos + diameter;
                        }
                        if (YPos > 200 - diameter)
                        {
                            YPos = YPos - diameter;
                        }
                        double XVel = Maths.XvelocityofElectron(WavelengthSlider.Value);// create function depending on the wavelenght slider
                        double YVel = ((myRand.NextDouble() * 10) - 5);
                        Ball ball;
                        ball = new Ball(diameter, XPos, YPos, XVel, YVel);

                        double lightIntensityProb = LightInSlider.Value;
                        Random rand = new Random();
                        int chance = rand.Next(0, 100);

                        if (chance > 100 - lightIntensityProb)
                        {
                            theBalls.Add(ball);
                        }


                    }


                }
            }

        }

        private void createBalls()
        {
            Ball ball;
            ball = new Ball(50, 250, 100, 0, 0);
            theBalls.Add(ball);
        }

        private void Render()
        {
            ElectronCanvas.Children.Clear();
            foreach (Ball drawBall in theBalls)
            {
                Ellipse theDrawnBall = new Ellipse();
                theDrawnBall.Height = 10;
                theDrawnBall.Width = 10;
                theDrawnBall.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 42));

                Canvas.SetLeft(theDrawnBall, drawBall.XPos);
                Canvas.SetTop(theDrawnBall, drawBall.YPos);
                ElectronCanvas.Children.Add(theDrawnBall);
            }

        }

        private void lightIntChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateLightIntensity();
            UpdateWavelength();
            UpdateVoltage();

        }

        public void WavelengthChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateLightIntensity();
            UpdateWavelength();
            UpdateVoltage();
            UpdateOutputValues();

        }

        private void UpdateLightIntensity()
        {
            if (LightInLabel != null)
            {
                //  Quanta quantaValues = new Quanta();
                double ChangedValue = quantaValues.LightIntensity;
                ChangedValue = LightInSlider.Value;                // assigns slider value to the light intensity slider
                LightInLabel.Content = "Light Intensity : " + ChangedValue + "%";   //sets the slider value to light intensity label
            }
        }

        private void UpdateWavelength()
        {
            if (WavelengthLabel != null && PhotonFrequencyLabel != null)
            {
                //   Quanta quantaValues = new Quanta()
                // uses the properties stored in the Quanta class
                double changedWavelength = WavelengthSlider.Value; // this is the slider value assigned to changedWavelength variable
                WavelengthLabel.Content = "Wavelength : " + changedWavelength + "nm";  // sets the wavelength value from slider to the label
                PhotonFrequencyLabel.Content = "Photon Frequency : " + Maths.ScientificNotation(Convert.ToDouble(Maths.WavelengthConverter(changedWavelength).ToString("N3"))); // sets photon frequency label equivalent to wavelenght selected on slider


                //THIS CHUNK OF CODE BELOW USES THE RBG CONVERTER FUNCTION TO ASSIGN WAVELENGTH TO ITS OWN RGB VALUES


                byte[] RGBArray = new byte[3];       // creates a array to store RGB VALUES
                RGBArray = RGBConverter.waveLengthToRGB(changedWavelength); // uses the fucntion in RBG converter to caluclate the RGB values from changedwavelength 
                LampColour.Fill = new SolidColorBrush(Color.FromRgb(RGBArray[0], RGBArray[1], RGBArray[2]));
                PhotonStream.Fill = new SolidColorBrush(Color.FromRgb(RGBArray[0], RGBArray[1], RGBArray[2]));
                PhotonStream.Opacity = LightInSlider.Value / 100;
                if (changedWavelength > 380 && changedWavelength < 750)
                {
                    WavelengthColourRectangle.Fill = new SolidColorBrush(Color.FromRgb(RGBArray[0], RGBArray[1], RGBArray[2]));
                    UVLabel.Content = "";

                }
                else if (changedWavelength < 380)
                {

                    UVLabel.Content = "UV Range";
                    WavelengthColourRectangle.Fill = Brushes.Purple;
                    LampColour.Fill = Brushes.Purple;
                    PhotonStream.Fill = Brushes.Purple;
                }
                else if (changedWavelength > 750)
                {
                    UVLabel.Content = "Infrared";
                    WavelengthColourRectangle.Fill = Brushes.Red;
                    LampColour.Fill = Brushes.Red;
                    PhotonStream.Fill = Brushes.Red;
                }


            }
        }

        private void sodiumSelected(object sender, RoutedEventArgs e)
        {
            SodiumUpdate();
            UpdateLightIntensity();
            UpdateWavelength();
            UpdateVoltage();
        }

        private void SodiumUpdate()
        {
            if (metal != null && PhotonFrequencyLabel != null)
            {
                MetalWorkFunction.currentMetal = conductiveMetal.sodium;
                metal.Fill = Brushes.Gray;
                WorkFunctionLabel.Content = "Work Function : " + DatabaseTestingç.MetalWorkFunction.sodiumWorkFunction + "eV";
                UpdateOutputValues();
            }
        }

        private void zincSelected(object sender, RoutedEventArgs e)
        {
            ZincUpdate();
            UpdateLightIntensity();
            UpdateWavelength();
            UpdateVoltage();
        }

        private void ZincUpdate()
        {
            if (metal != null && PhotonFrequencyLabel != null)
            {
                MetalWorkFunction.currentMetal = conductiveMetal.zinc;
                metal.Fill = Brushes.Brown;
                WorkFunctionLabel.Content = "Work Function : " + DatabaseTestingç.MetalWorkFunction.zincWorkFunction + "eV";
                UpdateOutputValues();
            }
        }

        private void aluminiumSelected(object sender, RoutedEventArgs e)
        {
            AluminiumUpdate();
            UpdateLightIntensity();
            UpdateWavelength();
            UpdateVoltage();
        }

        private void AluminiumUpdate()
        {
            if (metal != null && PhotonFrequencyLabel != null)
            {
                MetalWorkFunction.currentMetal = conductiveMetal.aluminium;
                metal.Fill = Brushes.LightGray;
                WorkFunctionLabel.Content = "Work Function : " + DatabaseTestingç.MetalWorkFunction.aluminiumWorkFunction + "eV";
                UpdateOutputValues();
            }
        }

        private void UpdateOutputValues()
        {
            double kineticenergy;
            kineticenergy = Maths.DisplayKineticEnergy(Maths.WavelengthConverter(WavelengthSlider.Value));
            if (kineticenergy > 0)
            {
                string stringvalue = Maths.ScientificNotation(kineticenergy);
                maxKineticEnergy.Content = "Max Kinetic Energy : " + stringvalue + "J";
              
            }
            else
            {
                maxKineticEnergy.Content = "Max Kinetic Energy : " + " 0";
            }
            string vmaxstring = Maths.ScientificNotation(Maths.DisplayElectronSpeed(Maths.WavelengthConverter(WavelengthSlider.Value)));
            maxElectronSpeed.Content = "Max Electron Speed : " + vmaxstring + "m/s";
        }

        private void ironSelected(object sender, RoutedEventArgs e)
        {
            IronUpdate();
            UpdateLightIntensity();
            UpdateWavelength();
            UpdateVoltage();
        }

        private void IronUpdate()
        {
            if (metal != null && PhotonFrequencyLabel != null)
            {
                MetalWorkFunction.currentMetal = conductiveMetal.iron;
                metal.Fill = Brushes.Black;
                WorkFunctionLabel.Content = "Work Function : " + DatabaseTestingç.MetalWorkFunction.ironWorkfunction + "eV";
                UpdateOutputValues();
            }
        }

        private void BatteryVoltageChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateWavelength();
            UpdateVoltage();// the problem im having here is that when i itry call teh wavelength and light intensity values it retruns them as 0
        }

        private void UpdateVoltage()
        {
            if (BatteryVoltageLabel != null)
            {
                double powerTemporary = 1.0;
                VoltageMeasurement voltage = new VoltageMeasurement();
                double batteryVoltageChanged = voltage.VoltageValue;
                //   Quanta quantaValues = new Quanta();
                double wavelength = WavelengthSlider.Value;
                double lightIntensity = LightInSlider.Value;
                batteryVoltageChanged = BatteryVoltage.Value;
                BatteryVoltageLabel.Content = "Voltage : " + batteryVoltageChanged + "V";
                string current = Maths.ScientificNotation(Current.GetCurrent(powerTemporary, WavelengthSlider.Value *(1e-9), LightInSlider.Value));
                CurrentReading.Content = "Current : " + current;
            }
        }

        private void QuantaInfo(object sender, RoutedEventArgs e)
        {

            InformationText.Text = "These two sliders are used to set the wavelenght and light intensity of the light source" +
                ". Adjusting the wavelength will change the colour and the spectrum of the light. The wavelength slider allows " +
                "for three different light spectrums to be displayed. " +
                "Most metals require UV light to release any electrons at all. Adjusting the wavelength slider" +
                "visually displays the colour of the light in repsect to the value its at. The light intensity" +
                " slider allows user to change light intensity which is visually represented by the dimming of the light released";

        }

        private void MetalSelectionInfo(object sender, RoutedEventArgs e)
        {
            InformationText.Text = "The dropbox allows the user to select between 4 different materials." +
                " The selection is visually represented by changing the colour of the terminal in respect" +
                "to the materail that has been selected.";
        }

        private void DisplayValueInfo(object sender, RoutedEventArgs e)
        {
            InformationText.Text = "This box outputs useful values in regard to the input values selected by the user.";

        }

        private void VoltageInfo(object sender, RoutedEventArgs e)
        {
            InformationText.Text = "The voltage slider allow user to change the voltage of the battery. " +
                "Changing the voltage of hte battery directlly affects the velocity of the electrons that are displayed." +
                "A positive voltage will cause electrons to accelerate because the terminal will be positive and we all" +
                " know that positive attracts negative so they speed up. However if the voltage is negative electrons will be repelled" +
                " andn will return back to the positvie termina which has been reversed. ";
        }

    }

}