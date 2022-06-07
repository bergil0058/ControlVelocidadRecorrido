using Abstractions;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ControlVelocidadRecorrido
{
    public class ControlVelocidadRecorrido
    {

        private ISolver Solver { get; }
        private IDataProvider Provider { get; }


        public ControlVelocidadRecorrido(ISolver aSolver, IDataProvider aDataProvider)
        {
            this.Solver = aSolver ?? throw new ArgumentNullException(nameof(aSolver));
            this.Provider = aDataProvider ?? throw new ArgumentNullException(nameof(aDataProvider));
        }



        public async Task Run()
        {                        
            List<Test> iTests = this.Provider.GetExerciseInput().Tests;
            
            List<TestResult> iResults = await this.TryExecuteTests(iTests);

            ExerciseOutput iOutput = this.BuildExerciseOutput(iResults);

            this.WriteOutput(iOutput);
        }

        private ExerciseOutput BuildExerciseOutput(List<TestResult> iResults)
        {
            // Build ouput
            return new()
            {
                Results = iResults,
                TestCount = iResults.Count
            };
        }

        private async Task<List<TestResult>> TryExecuteTests(List<Test> aTests)
        {
            List<TestResult> iResults = new();
            foreach (Test iTest in aTests)
            {
                iResults.Add(await TryExecuteTest(iTest));
            }
            return iResults;
        }

        private async Task<TestResult> TryExecuteTest(Test aTest)
        {
            TestResult? iRetVal = null;
            double iResult = -1;
            try 
            {
                 iResult = await this.Solver.GetMaximumConstantSpeedAsync(aTest);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                iRetVal = new TestResult()
                {
                    Number = aTest.Number
                    ,
                    Result = iResult
                };
            }
            return iRetVal;
        }

        private void WriteOutput(ExerciseOutput aTestResult)
        {
            if (aTestResult is null) throw new ArgumentNullException(nameof(aTestResult));

            XmlSerializer iSerializer = new(typeof(ExerciseOutput));
            using StreamWriter iSw = new("Exercise output.xml");
            iSerializer.Serialize(iSw, aTestResult);
        }
    }
}
