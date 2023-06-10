using CommunityToolkit.Mvvm.ComponentModel;
using NASMB.TYPES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ASMB.Models
{

    public partial class VoteState : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
        {
        [ObservableProperty]
        private int? paiming; //自己的投票票数
        [ObservableProperty]
        private BigInteger? votes; //自己的投票票数
        [ObservableProperty]
        private BigInteger? otherVotes; //别人给自己的投票

        [ObservableProperty]
        private string to;   //投票的目标地址,如果投票给自己，地址为空
                             //Slice      []byte   //投票的目标生产分片，如果投票给别人,目标分片为空
        [ObservableProperty]                   // 0:producing 消息锁 1:生产状态 2:
        private byte _lock; //  事务锁 ，
        [ObservableProperty]                   // 0:producing 消息锁 1:生产状态 2:
        private string marks; //  事务锁 ，
        public BigInteger? AllVotes { get { return votes + otherVotes; } }

    }
    public partial class Account :CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
      //  NASMB.TYPES.StateAccount stateAccount;
        //public Account(NASMB.TYPES.StateAccount stateAccount)
        //{
        //  //  this.stateAccount = stateAccount;
        //}
        //public Account(NASMB.TYPES.StateAccount account)
        //{

        //}

        public void copyfromStateact(NASMB.TYPES.StateAccount account) {

            Balance= account.Balance;
            LockedAmount = account.LockedAmount;
            if (votest == null)
            {
                Votest = new VoteState();
            }
            Votest.Lock = account.Votest.Lock;
            Votest.Votes = account.Votest.Votes;
            Votest.OtherVotes = account.Votest.OtherVotes;
            Votest.To = account.Votest.To;

            ExInfo = account.ExInfo;
            Receipts = account.Receipts;
        }

        [ObservableProperty]
        private string address;


        [ObservableProperty]
        private BigInteger? balance;
        [ObservableProperty]
        private BigInteger? lockedAmount; // 投票中（votes+），赎回中（balance +）
        [ObservableProperty]
        private VoteState votest;      // 投票和得票状态VoteState cid
                                      // 邀请人
        [ObservableProperty]           //
        private byte[] exInfo;// 附件数据
                              // 点对点交易 ：
                              //1)输出方签名以后发送给接收方，输出方如果余额不足时，如果接收方有意接收该未来票据
                              //	1.接收方把收到的票据保存，等输出方又余额时发送的网络进行确认
                              //	2.其他节点收到余额不足的交易直接丢弃
                              //	3.如果输出法秘钥修改，接收方需要将交易发送给输出者再次签名
                              // 节点确认时判断 nonce 是否是最新的切不能重复，如果不是最新的，

        [ObservableProperty]
        private byte[] receipts;//确认消息列表trie k
        [ObservableProperty]
        private ObservableCollection<Messagebs> messagebs;

        [ObservableProperty]
        private MetaEx metaEx;

        [ObservableProperty]
        private FrienddRemarks frienddRemarks;

        //[ObservableProperty]
        //private ObservableCollection<Messagebs> mymessagebs;
        // public event PropertyChangedEventHandler PropertyChanged;
        // public void OnPropertyChanged([CallerMemberName] string name = "") =>
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


    }
}
