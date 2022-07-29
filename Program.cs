// using System.Diagnostics;

// var acao1 = new Action(Processo1); //9° criando ações para inserir na variavel Parallel. O método Action é padrão da linguagem
// var acao2 = new Action(Processo2);//9°
// var acao3 = new Action(Processo3);//9°

// var stopWacth = new Stopwatch(); // 2° O stopWatch permite que possamos contar o tempo de processamento
// // ela é importada do namespace System.Diagnostics;

// stopWacth.Start(); //3° esses dois métodos vindo do stopwatch iniciam e finalizam a contagem do tempo do processo

// Parallel.Invoke(acao1, acao2, acao3); //8° Inserindo a classe Parallel (sem as ações), que recebe um invoke no qual precisara de uma action como parametro
// // 10° apagar os processos (5°) abaixo e inserir as acoes como metodo no invoke "Parallel.Invoke(acao1, acao2, acao3)". Ou seja, ele pegara o delegate (apontamento) dos processos
// // 1, 2, e 3 executando de forma paralela, o Invoke vai distribuir o processo em threads diferentes 

// // Processo1(); // 5° chamando os processos dentro do stopWatch
// // Processo2();
// // Processo3();

// stopWacth.Stop();// 3°

// Console.WriteLine($"o tempo de processamento é de {stopWacth.ElapsedMilliseconds} ms"); //4° vamos imprimir o tempo de processamento 
// //chamando o resultado da contagem do stopWatch com o ElapseMilliseconds como forma de contagem

// void Processo1() //1° vamos criar 3 métodos para criar processos e ações no sistema
// {
//     Console.WriteLine($"Processo 1 finalizado Thread: {Thread.CurrentThread.ManagedThreadId}");//1° e 7° ($"Processo 1 finalizado Thread: {Thread.CurrentThread.ManagedThreadId}")
//     //Inserido o $ + {Thread.CurrentThread.ManagedThreadId} para verificar em qual thread esta ocorrendo o processo
//     Thread.Sleep(1000); //6° vamos pedir para as threads aguardar 1000 milesundos, ]
//     //para verificar o tempo de execução em cada thread
// }

// void Processo2()//1°
// {
//     Console.WriteLine($"Processo 2 finalizado Thread: {Thread.CurrentThread.ManagedThreadId} ");//1° - 
//     Thread.Sleep(1000); //6°
// }

// void Processo3()//1°
// {
//     Console.WriteLine($"Processo 3 finalizado Thread: {Thread.CurrentThread.ManagedThreadId} ");//1° e 7°
//     Thread.Sleep(1000); //6°
// }

using System.Diagnostics;
using Paralelismo;

string[] ceps = new string[5]; // 14 °criado array para receber os valores de ceps com 5 posições
ceps[0] = "02263010"; //15° informando que cada ceps recebera um valor
ceps[1] = "02030100";
ceps[2] = "02750090";
ceps[3] = "04475470";
ceps[4] = "02815100";

var stopwatch = new Stopwatch(); //1°

var parallelOptions = new ParallelOptions(); //17° em ParallelOptions vamos conseguir definir a quantidade de Threads que vamos usar
parallelOptions.MaxDegreeOfParallelism = 8; //18° definimos que sera no maximo 8 Threads (nucleos da cpu) 

stopwatch.Start(); //2°



Parallel.ForEach(ceps,parallelOptions, cep => // 15° usando o Parallel com o for each, cria uma nova thread realocando cada thread em um local diferen, aumentando a velocidade do processo 
{
    Console.WriteLine(new ViaCepServices().GetCep(cep) + $"Thread: {Thread.CurrentThread.ManagedThreadId}"); // 16° imprimindo os valores de cep

}); 

foreach(var cep in ceps)//16° fazer um foreach para pegar os valores do array
{ 
   Console.WriteLine(new ViaCepServices().GetCep(cep) + $"Thread: {Thread.CurrentThread.ManagedThreadId}"); // 16° imprimindo os valores de cep
}

stopwatch.Stop();

Console.WriteLine($"O tempo de processamento total é de {stopwatch.ElapsedMilliseconds} ms"); //3°