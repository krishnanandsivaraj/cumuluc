using System;
using System.IO;
using System.Text;

using Newtonsoft.Json;

using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.DynamoDBv2.Model;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using System.Collections.Generic;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace s3dynamo
{
    public class Function
    {

        public async Task<bool> FunctionHandler(Rootobject input, ILambdaContext context)
        {
            List<string> inputitems = new List<string>();
            string ip = "";
            foreach (var item in input.value)
            {
                ip += item.Key.ToLower().Trim() + ",";
            }
            var client = new AmazonDynamoDBClient();
            var table = Table.LoadTable(client, "lookup");
            var resp = await table.GetItemAsync("F&B");
            var s = resp["value"];
            foreach (var item in s.ToString().Split(','))
            {
                if (ip.Contains(item.ToLower()))
                {
                    if (ip.Contains("coke"))
                    {
                        return true;
                    }
                }


            }

            return false;
        }

    }
}