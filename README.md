# IP.Geolocator

## Doel

Een klein programma in C# dat een IP-adres opzoekt en toont waar dat adres ongeveer vandaan komt. Het is gemaakt om te leren hoe IP-locaties werken en hoe je jezelf beschermt.

## Status

- Werkt: land, stad, coördinaten, postcode, regio en provider tonen
- Werkt: Google Maps link maken van de coördinaten
- Werkt: leeg laten van de invoer geeft je eigen publieke IP
- Werkt: foutmelding bij geen internet of een ongeldig adres

## Hoe werkt het?

1. Het programma toont de banner IP.Geolocator.
2. Jij typt een IP-adres. Typ je niets, dan gebruikt het programma je eigen publieke IP.
3. Het programma vraagt de gegevens op bij ipinfo.io via een gewone internetaanvraag (HTTPS).
4. ipinfo.io stuurt een antwoord in JSON terug. Dat is een tekstformaat met naam en waarde.
5. Newtonsoft.Json zet dat antwoord om naar een object, de klasse Data.
6. Het programma toont de gegevens en bouwt een Google Maps link met de coördinaten.


## Starten

Ga naar de projectmap en voer uit:

```
dotnet run Program.cs
```

## Beperkingen

- De locatie is de plek van de provider, vaak tientallen kilometers naast het echte adres.
- Bij een VPN of proxy zie je de locatie van de VPN-server.
- Bij een privé-IP krijg je geen locatie terug.
