using System.Collections.Generic;

namespace km.Collections.MultiZbior
{
    /// <summary>
    /// MultiSet, to rozszerzenie koncepcji zbioru, dopuszczające przechowywanie duplikatów elementów 
    /// </summary>
    /// <remarks>
    /// * Reprezentacja wewnętrzna: `Dictionary<T, int>`
    /// * Porządek zapamiętania elementów jest bez znaczenia, zatem {a, b, a} jest tym samym multizbiorem, co {a, a, b}
    /// * W konstruktorze można przekazać informację o sposobie porównywania elementów (`IEqualityComparer<T>`)
    /// </remarks>
    /// <typeparam name="T">dowolny typ, bez ograniczeń</typeparam>

    public interface IMultiSet<T> : ICollection<T>, IEnumerable<T>
    {

        // dodaje `numberOfItems` takich samych elementów `item` do multizbioru 
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        // zwraca referencję tej instancji multizbioru (`this`)
        public IMultiSet<T> Add (T item, int numberOfItems = 1);
        
        // usuwa `numberOfItems` elementów `item` z multizbioru,
        // jeśli `numberOfItems` jest większa niż liczba faktycznie przechowywanych elementów
        //   usuwa wszystkie
        // jesli elementu nie znaleziono - nic nie robi, nie zgłasza żadnego wyjątku
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        // zwraca referencję tej instancji multizbioru (`this`)
        public IMultiSet<T> Remove (T item,  int numberOfItems = 1);

        // usuwa wszystkie elementy `item`
        // jesli elementu nie znaleziono - nic nie robi, nie zgłasza żadnego wyjątku
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        // zwraca referencję tej instancji multizbioru (`this`)
        public IMultiSet<T> RemoveAll(T item);

        // dodaje sekwencję `IEnumerable<T>` do multizbioru
        // zgłasza `ArgumentNullException` jeśli `other` jest `null`
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        // zwraca referencję tej instancji multizbioru (`this`)
        public IMultiSet<T> UnionWith (IEnumerable<T> other);

        // modyfikuje bieżący multizbiór tak, aby zawierał tylko elementy wspólne z `other`
        // zgłasza `ArgumentNullException` jeśli `other` jest `null`
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        // zwraca referencję tej instancji multizbioru (`this`)
        public IMultiSet<T> IntersectWith(IEnumerable<T> other);

        // modyfikuje bieżący multizbiór tak, aby zawierał tylko te 
        // które nie wystepują w `other`
        // zgłasza `ArgumentNullException` jeśli `other` jest `null`
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        // zwraca referencję tej instancji multizbioru (`this`)
        public IMultiSet<T> ExceptWith(IEnumerable<T> other);

        // modyfikuje bieżący multizbiór tak, aby zawierał tylko te elementy
        // które wystepują w `other` lub występują w bieżacym multizbiorze,
        // ale nie wystepują równocześnie w obu
        // zgłasza `ArgumentNullException` jeśli `other` jest `null`
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        // zwraca referencję tej instancji multizbioru (`this`)
        public IMultiSet<T> SymmetricExceptWith(IEnumerable<T> other);

        // określa, czy multizbiór jest podzbiorem `other`
        // zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool IsSubsetOf(IEnumerable<T> other);

        // określa, czy multizbiór jest podzbiorem właściwym `other` (silna inkluzja)
        // zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool IsProperSubsetOf(IEnumerable<T> other);

        // określa, czy multizbiór jest nadzbiorem `other`
        // zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool IsSupersetOf(IEnumerable<T> other);

        // określa, czy multizbiór jest nadzbiorem właściwym `other` (silna inkluzja)
        // zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool IsProperSupersetOf(IEnumerable<T> other);

        // określa, czy multizbiór i `other` mają przynajmniej jeden element wspólny
        // zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool Overlaps(IEnumerable<T> other);

        // określa, czy multizbiór i `other` mają takie same elementy w tej samej liczności
        // nie zwracając uwagi na kolejność ich zapamiętania
        // zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool MultiSetEquals(IEnumerable<T> other);

        // określa, czy multizbiór jest pusty     
        public bool IsEmpty { get; }

        // zwraca obiekt wykorzystywany do określania równości elementów kolekcji
        public IEqualityComparer<T> Comparer { get; }
        // -------------------------


        // indexer, zwraca, dla zadanego `item`, liczbę jego powtórzeń w multizbiorze
        public int this[T item] { get; }

        // zwraca MultiSet jako Dictionary
        public IReadOnlyDictionary<T, int> AsDictionary();

        // zwraca MultiSet jako Set, usuwając duplikaty
        public IReadOnlySet<T> AsSet();


        // -------------------------
        // konstruktory, metody statyczne i operatory -> do zaimplementowania (nie da się zadeklarować w interfejsie)


        // zwraca pusty multizbiór
        public static IMultiSet<T> Empty { get; }

        /*
        // Konstruktor, tworzy pusty multizbiór
        public MultiSet();

        // Konstruktor, tworzy pusty multizbiór, w którym równość elementów zdefiniowana jest
        // za pomocą obiektu `comparer`
        public MultiSet(IEqualityComparer<T> comparer)

        // Konstruktor, tworzy multizbiór wczytując wszystkie elementy z `sequence`
        public MultiSet(IEnumerable<T> sequence)

        // Konstruktor, tworzy multizbiór wczytując wszystkie elementy z `sequence`
        // Równośc elementów zdefiniowana jest za pomocą obiektu `comparer`
        public MultiSet(IEnumerable<T> sequence, IEqualityComparer<T> comparer)

        // tworzy nowy multizbiór jako sumę multizbiorów `first` i `second`
        // zwraca `ArgumentNullException`, jeśli którykolwiek z parametrów jest `null`
        public static IMultiSet<T> operator +(IMultiSet<T> first, IMultiSet<T> second);

        // tworzy nowy multizbiór jako różnicę multizbiorów: od `first` odejmuje `second`
        // zwraca `ArgumentNullException`, jeśli którykolwiek z parametrów jest `null`
        public static IMultiSet<T> operator -(IMultiSet<T> first, IMultiSet<T> second);

        // tworzy nowy multizbiór jako część wspólną multizbiorów `first` oraz `second`
        // zwraca `ArgumentNullException`, jeśli którykolwiek z parametrów jest `null`
        public static IMultiSet<T> operator *(IMultiSet<T> first, IMultiSet<T> second);
        */
    }
}