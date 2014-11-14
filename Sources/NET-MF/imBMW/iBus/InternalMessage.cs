using System;
using imBMW.Tools;
using System.Text;

namespace imBMW.iBus
{
    public class InternalMessage : Message
    {
        string dataString;

        public InternalMessage(DeviceAddress device, string data)
            : this(device, Encoding.UTF8.GetBytes(data))
        { }

        public InternalMessage(DeviceAddress device, params byte[] data)
            : base((byte)device, (byte)((data.Length + 2) >> 8), data)
        {
            if (PacketLength > 1024)
            {
                throw new Exception("Message packet length exceeds 1024 bytes.");
            }
        }

        public DeviceAddress Device
        {
            get
            {
                return SourceDevice;
            }
        }

        private new DeviceAddress DestinationAddress
        {
            get
            {
                throw new Exception("No address in internal message.");
            }
        }

        public string DataString
        {
            get
            {
                if (dataString == null)
                {
                    dataString = Encoding.UTF8.GetString(Data);
                }
                return dataString;
            }
        }

        public static new Message TryCreate(byte[] packet, int length = -1)
        {
            if (length < 0)
            {
                length = packet.Length;
            }
            if (!IsValid(packet))
            {
                return Message.TryCreate(packet, length);
            }

            return new InternalMessage((DeviceAddress)packet[0], packet.SkipAndTake(3, ParseDataLength(packet)));
        }

        public static new bool IsValid(byte[] packet, int length = -1)
        {
            return IsValid(packet, ParsePacketLength, length) && packet[0].IsInternal();
        }

        public static new bool CanStartWith(byte[] packet, int length = -1)
        {
            return CanStartWith(packet, ParsePacketLength, length);
        }

        protected static new int ParsePacketLength(byte[] packet)
        {
            return (packet[2] << 8) + packet[1] + 2;
        }

        protected static new int ParseDataLength(byte[] packet)
        {
            return ParsePacketLength(packet) - 4;
        }
    }
}