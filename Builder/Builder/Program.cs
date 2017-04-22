using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        public interface IBuilder
        {
            void BuildCpu(Cpu cpu);
            void BuildGraph_card(Graph_card card);
            void BuildRAM(RAM ram);
            void BuildMemory(double memory);
        }
        public class CompBuilder : IBuilder
        {
            private Cpu _cpu;
            private Graph_card _card;
            private RAM _ram;
            private double _memory;


            public void BuildCpu(Cpu cpu) { this._cpu = cpu; }

            public void BuildGraph_card(Graph_card card) { this._card = card; }

            public void BuildRAM(RAM ram) { this._ram = ram; }

            public void BuildMemory(double memory) { this._memory = memory; }

            public Comp getResult()
            {
                return new Comp(_cpu, _card, _ram, _memory);
            }
        }
        public class Director
        {

            public void constructIntelComp(CompBuilder builder)
            {
                builder.BuildCpu(new Cpu());
                builder.BuildGraph_card(new Graph_card());
                builder.BuildRAM(new RAM());
                builder.BuildMemory(250);
            }

            public void constructAMDComp(CompBuilder builder)
            {
                builder.BuildCpu(new Cpu("AMD fx-8213"));
                builder.BuildGraph_card(new Graph_card("Radeon 560"));
                builder.BuildRAM(new RAM("DDR3"));
                builder.BuildMemory(500);
            }
        }
        static void Main(string[] args)
        {
            Director director = new Director();
            CompBuilder builder_1 = new CompBuilder();
            director.constructAMDComp(builder_1);
            Comp amdComp = builder_1.getResult();
            amdComp.Show();
            CompBuilder builder_2 = new CompBuilder();
            director.constructIntelComp(builder_2);
            Comp intelComp = builder_1.getResult();
            intelComp.Show();
        }
    }

    public class RAM
    {
        private string _ram_type;
        public string getRam() { return this._ram_type; }
        public RAM() { this._ram_type = "DDR3"; }
        public RAM(string ram) { this._ram_type = ram; }

    }

    public class Graph_card
    {
        private string _graph_card;
        public string getCard() { return this._graph_card; }
        public Graph_card() { this._graph_card = "NVIDIA geforce gtx 1080 ti"; }
        public Graph_card(string graph_card) { this._graph_card = graph_card; }
    }

    public class Cpu
    {
        private string _cpu;
        public string getCpu() { return this._cpu; }
        public Cpu() { _cpu = "Intel Dual Core"; }
        public Cpu(string cpu)
        {
            _cpu = cpu;
        }
    }
}
