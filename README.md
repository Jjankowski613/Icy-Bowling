# ICY BOWLING – README.md

## Opis projektu
**ICY BOWLING** to prototypowa gra VR zrealizowana w Unity z wykorzystaniem XR Interaction Toolkit. Projekt symuluje grę w kręgle w wirtualnym pokoju stylizowanym na klimat gry Icy Tower. Gracz może chwytać kulę bowlingową i rzucać nią w kierunku kręgli, które fizycznie reagują na uderzenie. Gra przeznaczona jest na gogle Oculus Rift.

## Technologia
- Unity (2021+)
- XR Interaction Toolkit
- C# (Unity scripts)
- Fizyczny silnik gry (RigidBody, Collider)
- Platforma: PC VR (Oculus Rift)

## Cele projektu
- Stworzenie immersyjnego doświadczenia VR z fizyczną interakcją.
- Praktyczne zastosowanie chwytania i rzutu obiektów w XR.
- Zastosowanie realistycznej fizyki i stylizacji wizualnej.

## Odbiorcy
- Użytkownicy Oculus Rift zainteresowani rozrywką VR.
- Gracze casualowi i entuzjaści technologii XR.
- Fani klimatu retro / Icy Tower.

## Wartość dla użytkownika
- Naturalne sterowanie ruchem.
- Realistyczna fizyka kręgli i kuli.
- Stylizowane otoczenie, oprawa dźwiękowa i wibracje.

---

## Wymagania funkcjonalne

### FR1: Chwytanie kuli
- Chwyt możliwy po zbliżeniu ręki do obiektu i naciśnięciu spustu.
- Kula podąża za ręką w sposób płynny.

### FR2: Rzut i fizyczne trafienie w kręgle
- Rzut oparty o ruch ręki w momencie puszczenia spustu.
- Kręgle reagują fizycznie, mogą się przewrócić.

### FR3: Stylizowane otoczenie Icy Tower
- Lodowa kolorystyka i modele.
- Platformy i plakaty nawiązujące do stylu retro.

### FR4: Zliczanie i wyświetlanie wyniku
- Po rzucie gra liczy przewrócone kręgle.
- Wynik wyświetlany jako tekst 3D.

### FR5: Restart rozgrywki
- Automatyczne lub manualne rozstawienie kręgli i reset pozycji kuli.

## Wymagania niefunkcjonalne

### NF1: Płynność działania
- 90 FPS na Oculus Rift.
- Optymalizacja fizyki i renderingu.

### NF2: Intuicyjność
- Brak zbędnych UI 2D.
- Naturalne sterowanie i komfort gry.

---

## Priorytetyzacja
- **Wysoki priorytet**: FR1, FR2, NF1, NF2
- **Średni**: FR3, FR4
- **Niski**: FR5

---

## Zaimplementowane funkcjonalności

### 1. Chwytanie i rzucanie kuli
- Model z XR Grab Interactable.
- Fizyczne śledzenie ruchu ręki.
- Rzut z zachowaniem trajektorii i pędu.

### 2. Trafienie w kręgle + punktacja
- Ustawione kręgle z RigidBody.
- Kolizje z kulą.
- System zliczania trafień i wyświetlanie wyniku.

---

## Decyzje immersyjne
- Chwyt i rzut ruchem ręki (XR Grab).
- Haptyka: wibracje przy chwycie i uderzeniu.
- Stylizowana oprawa graficzna + dynamiczne światło.
- Efekty dźwiękowe: kula, kręgle, ambient wieży.

---

## Przebieg demonstracji
1. Gracz zakłada gogle Oculus Rift.
2. Znajduje się w pokoju VR (styl Icy Tower).
3. Chwyta kulę VR i rzuca w kręgle.
4. Obserwuje efekt fizyczny.
5. Widzi wynik na tablicy.
6. Gra resetuje się do nowej rundy.

---

## Autorzy
Projekt na zaliczenie przedmiotu „Programowanie systemów VR” (WSB w Poznaniu) utworzony przez: Jakub Jankowski.
- Gogle: Oculus Rift
- Silnik: Unity
- Technologia: XR Interaction Toolkit
