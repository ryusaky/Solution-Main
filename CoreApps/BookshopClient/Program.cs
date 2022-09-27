using Grpc.Net.Client;
using Bookshop;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("http://localhost:5000");
var client = new ChallengeUsers.ChallengeUsersClient(channel);
//test
//var reply = await client.GetAllUsersAsync(new GetUserListRequest { });

//first question
//var firstQuestion = client.GetUserById(new RequestId { Id = 1708 });
//Console.WriteLine("First Question: " + firstQuestion);
//second question

//third question

//fourth question
//var fourthQuestion = await client.GetAllGoalsByUserIdAsync(new RequestId { Id = 1708 });
//Console.WriteLine("fourth Question: " + fourthQuestion.Goal);

//fifth question
var fifthQuestion = await client.GetDetailforGoalAsync(new RequestUserIdAndGoalId { Userid = 1708, Goalid = 3003 });
Console.WriteLine("fifth Question: " + fifthQuestion.Goal);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();