# IP.Geolocator

## Doel

Een klein programma in C# dat een IP-adres opzoekt en toont waar dat adres ongeveer vandaan komt. Het is gemaakt om te leren hoe IP-locaties werken en hoe je jezelf beschermt.

## Status

- Werkt: land, stad, coördinaten, postcode, regio en provider tonen
- Werkt: Google Maps link maken van de coördinaten
- Werkt: leeg laten van de invoer geeft je eigen publieke IP
- Werkt: foutmelding bij geen internet of een ongeldig adres

## Herkomst / Inspiratie

- **Wie**: MDB
- **Waar**: gemaakt in VS Code als oefenproject
- **Wanneer**: oktober 2026

## Hoe werkt het?

1. Het programma toont de banner IP.Geolocator.
2. Jij typt een IP-adres. Typ je niets, dan gebruikt het programma je eigen publieke IP.
3. Het programma vraagt de gegevens op bij ipinfo.io via een gewone internetaanvraag (HTTPS).
4. ipinfo.io stuurt een antwoord in JSON terug. Dat is een tekstformaat met naam en waarde.
5. Newtonsoft.Json zet dat antwoord om naar een object, de klasse Data.
6. Het programma toont de gegevens en bouwt een Google Maps link met de coördinaten.

Kernbegrippen:

- **IP-adres**: het nummer van een toestel op het internet. Je gebruikt het om te weten wie met wie praat.
- **Publiek IP**: het adres dat websites van jou zien. Een privé-adres zoals 192.168.x.x werkt hier niet, want dat bestaat alleen in je eigen netwerk.
- **JSON**: een manier om gegevens als tekst door te sturen. Je gebruikt het omdat bijna elke website-dienst dit snapt.
- **Nullable (het vraagteken bij string)**: zegt dat een waarde ook leeg mag zijn. Je gebruikt het zodat het programma niet crasht als ipinfo een veld niet teruggeeft.

## Onderdelenlijst

- .NET SDK 10 (installeren met winget install Microsoft.DotNet.SDK.10)
- Newtonsoft.Json 13.0.3 (staat bovenaan het bestand als package-regel)
- ipinfo.io (gratis, met een daglimiet zonder token)
- VS Code met de C# extensie

## Starten

Ga naar de projectmap en voer uit:

```
dotnet run Program.cs
```

## Beperkingen

- De locatie is de plek van de provider, vaak tientallen kilometers naast het echte adres.
- Bij een VPN of proxy zie je de locatie van de VPN-server.
- Bij een privé-IP krijg je geen locatie terug.

## Logboek

- **2026-10-16**: SDK geïnstalleerd, null-controles toegevoegd, Google Maps link en banner gemaakt

## Volgende stappen

- Ideeën: kleur in de uitvoer, meerdere IP-adressen na elkaar opzoeken, resultaat opslaan in een bestand

## Kort samengevat

IP.Geolocator vraagt een IP-adres, zoekt het op bij ipinfo.io en toont de ruwe locatie met een Google Maps link.