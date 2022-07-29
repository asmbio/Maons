using CommunityToolkit.Mvvm.ComponentModel;
using NASMB.TYPES;
using Nethereum.RLP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ASMBApp.Models
{
    public partial class Transmsg : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        [ObservableProperty]
        private Msgtype header = Msgtype.SignTrans; // models.Trans
        [ObservableProperty]
        private AsmbAddress from;
        [ObservableProperty]
        private AsmbAddress to;
        [ObservableProperty]
        private BigInteger balance;

        [ObservableProperty]
        private UInt64 feesrate;
        [ObservableProperty]
        private string marks="";
        [ObservableProperty]
        private UInt64 time;

        public byte[] RlpEncode()
        {
            //var mbytes =Marks.ToBytesForRLPEncoding();
            return RLP.EncodeDataItemsAsElementOrListAndCombineAsList(new byte[][] {
                RLP.EncodeByte((byte)Header),
                From.GetAddressbyte(),
                To.GetAddressbyte() ,
                Balance.ToBytesForRLPEncoding(),
              ConvertorForRLPEncodingExtensions.ToBytesFromNumber(BitConverter.GetBytes( Feesrate)),
              Marks.ToBytesForRLPEncoding(),
                ConvertorForRLPEncodingExtensions.ToBytesFromNumber(BitConverter.GetBytes( Time)),
            });

        }

        public Transmsg RlpDecode(byte[] row)
        {

            //var decodedList = RLP.Decode(row);
            //var decodedElements = (RLPCollection)decodedList;
            //Transmsg transmsg = new Transmsg();
            //transmsg.Header = RLP.Decode(decodedElements[0].RLPData);

            return null;
        }
    }
}
