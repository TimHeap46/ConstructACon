namespace App1.Models.Household
{
    public class Door
    {
        public Door()
        {
            DoorType = new KeyValue();
            LockType = new KeyValue();
        }
        public KeyValue DoorType { get; set; }
        public KeyValue LockType { get; set; }
    }
}