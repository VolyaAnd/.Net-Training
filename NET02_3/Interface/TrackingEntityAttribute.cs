using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Создать атрибуты[TrackingEntity] и [TrackingProperty]. Дополнить логгер методом Track(),
принимающим в качестве параметра произвольный объект. Если у класса или структуры, 
соответствующих типу объекта, обнаруживается наличие атрибута [TrackingEntity], логгер 
 фиксирует(т.е.пишет в лог-файл с уровнем Trace) значения тех свойств и полей объекта, 
которые помечены атрибутом [TrackingProperty]. Значения фиксируются как пары «имя=значение»,
где «имя» — это либо
*/
namespace Interface
{
    public class TrackingEntityAttribute : System.Attribute
    {

    }
}
