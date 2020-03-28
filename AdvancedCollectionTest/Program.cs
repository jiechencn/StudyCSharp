using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCollectionTest
{   enum Flags:int
    {
        FLAG_HAS_CHANGE = 0,
        FLAG_HAS_ATTACHMENT = 1,
        FLAG_HAS_MFR = 2,
        FLAG_HAS_BOM = 3,
        FLAG_SOFT_DELETED = 4,
        FLAG_IS_RELEASED = 5,
        FLAG_IS = 6,
        FLAG_07 = 7            
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("-------------------- BitArray");
            var item_flag = new BitArray(8);
            item_flag.SetAll(false);
            item_flag.Set((int)Flags.FLAG_HAS_ATTACHMENT, true);
            item_flag.Set((int)Flags.FLAG_HAS_BOM, true);
            Console.WriteLine(GetFlagString( item_flag));

            Console.WriteLine("-------------------- ObservableCollection");
            var groups = new ObservableCollection<string>();
            groups.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler( DataCollectionChanged);
            //groups.CollectionChanged += DataCollectionChanged; //same as above
            groups.Add("hello1");
            groups.Add("hello2");
            groups.Add("hello3");
            groups.Add("hello4");
            groups.Remove("hello2");


        }

        private static void DataCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                Console.WriteLine("old items are added: ");
                foreach(var item in e.OldItems)
                {
                    Console.WriteLine(" -- old item :" + item);
                }
            }else if (e.NewItems != null)
            {
                Console.WriteLine("new items are added: ");
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine(" -- new item :" + item);
                }
            }

        }

        public static string GetFlagString(BitArray ba)
        {
            var sb = new StringBuilder();
            for (int i = ba.Length - 1; i >= 0; i--)
            {
                sb.Append(ba.Get(i)?1:0);
            }
            return sb.ToString();
        }

    }

}
