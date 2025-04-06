using System.Collections;
//definicion e inicializacion de los arreglos en paralelo y el diccionario
String[] Departamento = { "Boaco", "Carazo", "Chinandega", "Chontales", "Costa Caribe Norte", "Costa Caribe Sur", "Estelí", "Granada", "Jinotega", "León", "Madriz", "Managua", "Masaya", "Matagalpa", "Nueva Segovia", "Río San Juan", "Rivas" };
int[] Poblacion = { 185103, 197139, 399206, 190893, 530586, 414523, 229866, 213417, 475630, 421050, 174744, 1456399, 391903, 593503, 271581, 135446, 182645 };
Dictionary<string, int> diccionario = Departamento
    .Zip(Poblacion, (k, v) => new { Clave = k, Valor = v })
    .ToDictionary(x => x.Clave, x => x.Valor);
//Ordenando el diccionario de menor a mayor
var ordenado = diccionario.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
//Extrayendo los nombres de los departamentos con menor y mayor población
string minDepkey = ordenado.First().Key;
string maxDepkey = ordenado.Last().Key;
//reasignación de los arreglos en paralelo
Departamento = ordenado.Keys.ToArray();
Poblacion = ordenado.Values.ToArray();
//Mostrar los departamentos de menor a mayor.
for (var i = 0; i < Poblacion.Length; i++)
    Console.WriteLine($"{Departamento[i],20} ==> {Poblacion[i],10:N0}");
//Suma de toda la población y nombre de mayor y menor
Console.WriteLine($"Población General:{Poblacion.Sum():N0}");
Console.WriteLine($"Departamento con mayor Población:{maxDepkey}");
Console.WriteLine($"Departamento con menor Población:{minDepkey}");
