using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Builder
{
    internal class Comp
    {
        public Comp() { }
        public Comp(Cpu cpu, Graph_card card, RAM ram, double memory)
        {
            _cpu = cpu;
            _card = card;
            _ram = ram;
           _memory = memory;
        }
        private Cpu _cpu{ set; get; }
        private Graph_card _card{set;get;}
        private RAM _ram{ set;get;}
        private double _memory{set;get;}
       
        public void Show()
        {
            Console.WriteLine("CPU:{0} \n CARD:{1} \n RAM:{2} \n MEMORY:{3}", this._cpu.getCpu(), this._card.getCard(), this._ram.getRam(), this._memory);
        }
    }
}