//Automata
using CERDIK;

public enum deviceState { BelumLogin, SudahLogin, Blocked, Suspended }
public enum Trigger { Block, Unblock, Suspend, Unsuspend, Login, Logout }
public class Devices
{
    public DevicesConfig config;

    public Devices(DevicesConfig config)
    {
        this.config = config;
    }


    public class kondisiElectronics
    {
        public deviceState stateAwal;
        public deviceState stateAkhir;
        public Trigger trigger;

        public kondisiElectronics(deviceState stateAwal, deviceState stateAkhir, Trigger trigger)
        {
            this.stateAwal = stateAwal;
            this.stateAkhir = stateAkhir;
            this.trigger = trigger;
        }
    }
    kondisiElectronics[] transisi =
    {
        new kondisiElectronics(deviceState.BelumLogin, deviceState.SudahLogin, Trigger.Login),
        new kondisiElectronics(deviceState.SudahLogin, deviceState.BelumLogin , Trigger.Login),
        new kondisiElectronics(deviceState.BelumLogin, deviceState.Blocked , Trigger.Block),
        new kondisiElectronics(deviceState.SudahLogin, deviceState.Blocked , Trigger.Block),
        new kondisiElectronics(deviceState.Blocked, deviceState.BelumLogin, Trigger.Unblock),
        new kondisiElectronics(deviceState.BelumLogin, deviceState.Suspended , Trigger.Suspend),
        new kondisiElectronics(deviceState.SudahLogin, deviceState.Suspended , Trigger.Suspend),
        new kondisiElectronics(deviceState.Suspended,deviceState.BelumLogin , Trigger.Unsuspend)
    };
    public deviceState currentState = deviceState.BelumLogin;

    public deviceState GetNextState(deviceState stateAwal, Trigger trigger)
    {
        deviceState stateAkhir = stateAwal;
        for (int i = 0; i < transisi.Length; i++)
        {
            kondisiElectronics perubahan = transisi[i];
            if (stateAwal == perubahan.stateAwal && trigger == perubahan.trigger)
            {
                stateAkhir = perubahan.stateAkhir;
            }
        }
        return stateAkhir;
    }
    public void ActivateTrigger(Trigger trigger)
    {

        currentState = GetNextState(currentState, trigger);

        if (currentState == deviceState.Blocked)
        {
            Console.WriteLine("Perangkat berhasil diblock");
        }
        else if (currentState == deviceState.BelumLogin && trigger == Trigger.Unblock)
        {
            Console.WriteLine("Perangkat berhasil di Un-blocked");
        }
        else if (currentState == deviceState.SudahLogin)
        {
            Console.WriteLine("Perangkat ini Telah masuk ke akun anda");
        }
        else if (currentState == deviceState.BelumLogin && trigger == Trigger.Logout)
        {
            Console.WriteLine("Perangkat ini Telah di log-out");
        }
        else if (currentState == deviceState.Suspended)
        {
            Console.WriteLine("Maaf perangkat ini sedang disuspend admin");
        }
        else if (currentState == deviceState.BelumLogin && trigger == Trigger.Suspend)
        {
            Console.WriteLine("Selama anda dapat menggunakan perangkat ini lagi");
        }
        Console.WriteLine("Status perangkat ini: " + currentState);
    }

}
