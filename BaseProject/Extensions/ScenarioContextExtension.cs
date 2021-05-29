using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BaseProject.Extensions
{
    public static class ScenarioContextExtension
    {
        public static void UpdateFromTable(this ScenarioContext context, Table table)
        {
            foreach (var row in table.Rows)
            {
                foreach (var datum in row)
                {
                    if (context.ContainsKey(datum.Key))
                    {
                        context[datum.Key] = datum.Value;
                    }
                    else
                    {
                        context.Add(datum.Key, datum.Value);
                    }
                }
            }
        }
    }
}
