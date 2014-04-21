using System;
using Microsoft.SPOT;
using imBMW.iBus.Devices.Real;

namespace imBMW.Features.Menu.Screens
{
    public class BordcomputerScreen : MenuScreen
    {
        protected static BordcomputerScreen instance;

        protected MenuItem itemPlayer;
        protected MenuItem itemFav;
        protected MenuItem itemBC;
        protected MenuItem itemSettings;

        protected BordcomputerScreen()
        {
            // TODO
            //BodyModule.UpdateBatteryVoltage();
            /*Bordmonitor.ShowText("��������:   " + InstrumentClusterElectronics.CurrentSpeed + "��/�", BordmonitorFields.Item, 0);
            Bordmonitor.ShowText("�������:    " + InstrumentClusterElectronics.CurrentRPM, BordmonitorFields.Item, 1);
            Bordmonitor.ShowText("���������:  " + InstrumentClusterElectronics.TemperatureCoolant + "�C", BordmonitorFields.Item, 2);
            //Bordmonitor.ShowText("�����:      " + InstrumentClusterElectronics.TemperatureOutside + "�C", BordmonitorFields.Item, 3);
            Bordmonitor.ShowText("����������: " + BodyModule.BatteryVoltage + "�", BordmonitorFields.Item, 3);*/
            this.AddBackButton();
            SetItems();
        }

        protected virtual void SetItems()
        {
            ClearItems();
            //AddItem(itemPlayer);
        }

        public static BordcomputerScreen Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BordcomputerScreen();
                }
                return instance;
            }
        }
    }
}
