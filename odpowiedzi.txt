Przeanalizuj poniższy kod i odpowiedz na pytania:
1. Kiedy istnieje konieczność zarządzania zasobami za pomocą metody Dispose()?
Czy metodę Dispose() można przeciążać? Jeśli tak to w jakim celu?
2. Wyjaśnij czy oba poniższe programy z punktu a) oraz b) są poprawne? Krótko
uzasadnij.

ad. 1:
zarządzanie zasobami niezarządzalnymi, tj. gdy klasa korzysta z zasobów nieużywanych przez garbage collecotr (np. zapięcie do pliku, 'using')
tak, można przeciążać, np. w celu wywołania wewnątrz Dispose() metody zakmnięcia dostępu do pliku/połączenia do connection poola

ad. 2:
a) poprawny, zamyka dostep do pliku przy użyciu Dispose() które wykonuje się samo po wykończeniu kodu z klauzuli "using"
b) poprawny ale średnio bezpieczny bo trzeba zamykać dostęp do pliku ręcznie 