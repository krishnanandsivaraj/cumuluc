using System;
using System.IO;
using System.Text;

using Newtonsoft.Json;

using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2;
using System.Collections.Generic;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace dynamodb
{
    public class Input
    {
        public string value { get; set; }
    }

    public class Function
    {
        
        public async Task<bool> FunctionHandler(Input input, ILambdaContext context)
        {
            string ip = input.value;
            var client = new AmazonDynamoDBClient();
            var table = Table.LoadTable(client, "lookup");
            var resp=await table.GetItemAsync("F&B");
            var s = resp["value"];
            foreach (var item in s.ToString().Split(','))
            {
                if (ip.Contains(item)) {
                    if (ip.Contains("coke")) {
                        return true;
                    }
                }


            }

            return false;
        }

    }
}