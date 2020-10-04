using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 第一种，简单的事件订阅，动物饲养员只要一吹口哨，动物们就过来吃饭。
            // 饲养员是事件发布者，动物们是订阅者，事件是吹口哨

            Zooman zooman = new Zooman();
            var dog = new Animal("dog");
            var cat = new Animal("cat");
            zooman.EatSignal += dog.Eat;
            zooman.EatSignal += cat.Eat;
            zooman.SendEatSignal();

            zooman.SleepSignal += dog.Sleep;
            zooman.SleepSignal += cat.Sleep;
            zooman.SendSleepSignal();

            // 第二种， 复杂的event事件订阅，事件信息本身含有参数
            // 楼盘销售员是事件发布者，业主买家是订阅者。发布者发布的事件是楼盘信息开盘了，参数为楼盘名称和价格，这两个参数需要发布给买家
            Broker houseSeller = new HouseBroker();  //卖别墅的房产销售员
            Broker appartSeller = new AppartmentBroker(); //卖公寓房的房产销售员

            var jerry = new Consumer("Jerry mouse"); //
            var tom = new Consumer("Tom cat");

            houseSeller.BrokerEvent += jerry.SubscriberBrokerEvent;  // jerry在别墅销售员那里登记了自己的手机号，等销售员的电话通知
            houseSeller.BrokerEvent += tom.SubscriberBrokerEvent; // tom在别墅销售员那里登记了自己的手机号，等销售员的电话通知
            appartSeller.BrokerEvent += tom.SubscriberBrokerEvent; // tom在公寓房销售员那里登记了自己的手机号，等销售员的电话通知

            houseSeller.Publish("mingmen 1 hao", 23560);  // 别墅销售员发布通知，别墅开盘了
            appartSeller.Publish("8 hao", 12300);   // 公寓房销售员发布通知，公寓开盘了

            Console.Read();
        }
    }
}
