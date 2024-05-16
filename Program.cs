// See https://aka.ms/new-console-template for more information
using SBase.Helper;

CryptographyHelper.RSAHelper rsa = new CryptographyHelper.RSAHelper();

var publicKeyUser1 = rsa.GeneratePublicKey();
var publicKeyUser2 = rsa.GeneratePublicKey();
var publicKeyUser3 = rsa.GeneratePublicKey();

string data = "User 1";
string data2 = "User 2";
string data3 = "User 3";

string cypherText = rsa.Encrypt(data, publicKeyUser1);
string cypherText2 = rsa.Encrypt(data2, publicKeyUser2);
string cypherText3 = rsa.Encrypt(data3, publicKeyUser3);

Console.WriteLine(cypherText);
Console.WriteLine(cypherText2);
Console.WriteLine(cypherText3);


Console.WriteLine(rsa.Decrypt(cypherText));
Console.WriteLine(rsa.Decrypt(cypherText2));
Console.WriteLine(rsa.Decrypt(cypherText3));