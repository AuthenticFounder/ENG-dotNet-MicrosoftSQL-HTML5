>> 19:30 16.10.2022
----------------
Eesmärk
-C# keel
-objekt-orienteeritud programmeerimise üldtunnustatud arendusmustrite/võtete tundmine ja kasutamise oskused
-enda loodava tarkvara dokumenteerimine
-kvaliteedi kontroll

Sisukirjeldus:
Realiseerida alljärgnev äriülesanne kasutades domeenipõhise disaini (domain-driven design) printsiipe
kihilist arhitektuuri koos sobivate arendusmustritega (märksõnad: nõrgad seosed kihtide vahel, dependency injection, inversion of control).

Luua visuaalse kasutajaliides kasutades kaustas „UI materjal“ olevaid juhiseid.

Luua andmebaas ja andmebaasi diagramm.
Andmebaasi osas võib loodav rakendus kasutada vabalt valitud abstraktsiooni (Microsoft SQL Server, SQLite, PostgreSQL, Oracle vms).

Koostada automaattestid tarkvara toimimise kontrollimiseks vastavalt etteantud nõuetele. Testimisraamistik vabal valikul.

Koostada minimaalne vajalik dokumentatsioon.
Dokumentatsioon on vajalik rakenduse paigaldamise kirjeldamiseks,
üldise ettekujutuse saamiseks rakenduse arhitektuurist (erinevate kihtide rollid rakenduses),
rakenduse koodi mõistmiseks (kui rakenduses dokumenteerib kood ennast ise, siis koodi kohta dokumentatsiooni pole vaja).

Mittefunktsionaalsed nõuded:
Veebirakendus peab olema realiseeritud C# programmeerimiskeeles uusimat .NET raamistikku kasutades.

Arendusvahendina on soovitatav kasutada uusimat Visual Studio versiooni

Rakenduse kood peab olema vigadeta kompileeruv ning eelneva seadistuseta Visual Studiost avatav ning käivitatav.

Kasutajaliides peab vastama HTML5 standardile
kasutajaliidese loomisel on soovitatav võtta aluseks mõni raamistik (näiteks Bootstrap).

Kasuta töös avalikult kättesaadavat Git repositooriumi (näiteks üks kolmest kõige levinumast: GitHub, GitLab või Bitbucket).
Töö käik peab olema hindaja poolt versioonihaldusest selgelt jälgitav.

Äriülesanne:
Luua külaliste registreerimissüsteem, mis peab võimaldama lisada/muuta tulevikus
toimuvaid üritusi ja vaadata juba toimunud üritusi.
Kasutaja saab vajadusel tulevikus toimuvaid üritusi ka kustutada.
Igale üritusele peaks saama lisada osavõtjaid, kes jagunevad eraisikuteks ning juriidilisteks isikuteks (ettevõtted).
Salvestatud osavõtjate andmeid peab saama vaadata, muuta ning vajadusel kustutada,
lisaks peab salvestatud olemasolevaid osavõtjaid saama lisada teistele üritustele.
Iga ürituse puhul peab saama näha täielikku nimekirja külalistest.

Funktsionaalsed nõuded:
-Avaleht
-Ürituse lisamise vaade
-Üritusest osavõtvate isikute vaade
-Osavõtja lisamise vaade
-Osavõtja detailandmete vaatamise-muutmise vaade

Avaleht – Sisaldab loetelu toimunud ja tulevikus toimuvatest üritustest.
Visuaalselt kuvatakse ürituse nimi, aeg, koht, osavõtjate arv.
Link või nupp osavõtja lisamiseks (mis viib osavõtja lisamise vormile) ja
ürituse kustutamise võimalus tulevikus toimuvate ürituste osas
(kustutab nii ürituse kui ka üritusele registreerunud osavõtjad).
Lisaks peab olema võimalus liikuda ürituse lisamise vormile.

Ürituse lisamise vaade – Sisaldab vormi, millega saab lisada uusi tulevikus toimuvaid üritusi.
Vormilt peaks saama sisestada järgmiseid andmeid:
ürituse nimi,
toimumisaeg (saab sisestada ainult tuleviku kuupäeva ja kellaaega),
toimumise koht,
lisainfo (maksimaalselt 1000 tähemärki),
lisamise nupp ja tagasi nupp avalehele navigeerimiseks.
Peale ürituse lisamist võiks toimuda automaatne suunamine avalehele.

Üritusest osavõtvate isikute vaade – Vajutades avalehel ürituse nimele peaks avanema vaade kõikide üritusest
osavõtvate isikute loeteluga.
Loetelus peaks iga isiku kohta olema ees- ja perekonnanimi (ettevõtte puhul juriidiline nimi),
isikukood (ettevõtte puhul registrikood),
ürituselt kustutamise võimalus
ning tagasi nupp avalehele navigeerimiseks.

Osavõtja lisamise vaade – Avalehel on iga ürituse taga nupp või link osavõtja lisamiseks, mis viib eraldi vormile.
Vormil peab olema valik kas soovitakse lisada füüsilist või juriidilist isikut
ning vastavalt tehtud valikule peab olema võimalik sisestada järgmiseid andmeid:

Eraisik/Ettevõte

Eesnimi/Ettevõtte juriidiline nimi
Perekonnanimi/Ettevõtte registrikood
Isikukood/Ettevõttest tulevate osavõtjate arv
Osavõtumaksu maksmise viis (valik: pangaülekanne või sularaha)
Lisainfo väli (maksimaalselt 1500/5000 tähemärki), osalejapoolsed soovid

Teeme eelduse, et kõikidel füüsilisest isikust osavõtjatel on Eesti isikukoodi
ning sisestamisel valideeritakse selle korrektsust.
Makseviise peab saama hallata ilma lähtekoodi muutmata.
Vormil on lisaks  salvestamise nupp ja tagasi nupp avalehele navigeerimiseks.
Peale osavõtja lisamist võiks toimuda automaatne avalehele suunamine.

Osavõtja detailandmete vaatamise/muutmise vaade – üritusest osavõtvate isikute vaatest isikule vajutades avaneb vaade,
kus on võimalik vaadata ja muuta osavõtja lisamise vormilt salvestatud andmeid.


----------------------------------------------------------------------------------------------------------------
Logi:

----------------
STAGE 1
----------------

>> 20:00 16.10.2022
----------------
Ideed:
-Log (Diagnostika eesmärgil, ilmselt raske lugeda, kuid tuleb hiljem kasuks)

>> 21:30 16.10.2022
----------------
-Bootstrap Inspektsioon

>> 23:30 16.10.2022
----------------
Tarkvara allalaadimine ja seadistus.

>> 01:00 17.10.2022
----------------
Tehnilised raskused SQL serveri paigaldusega, seoses operatsiooni süsteemi teenustega (VSS keeldub toimimast...)

>> 09:30 17.10.2022
----------------
OS sai uuesti installitud ning keskkond ette valmistatud.

>> 11:00 17.10.2022
----------------
SQL Ettevalmistused

>> 17:00 18.10.2022
----------------
Paus (ja haigestusin ka)

>> 20:00 18.10.2022
----------------
Projekti Loomine Valik 1
(CMD käsud)
cd.. (navigeerida C kettale)
mkdir NETAPP (luua projekti kaust)
cd NETAPP (navigeerida kausta 'C:\NETAPP')
dotnet
dotnet new webapp -o MyWebApp -f net6.0 (loob projekti kausta 'C:\NETAPP')
cd MyWebApp
dotnet watch (käsklus loob ja käivitab applikatsiooni, Ctrl+C sulgeb applikatsiooni, soovi korral võib kasutada käsklust dotnet run ning siis käsitsi host..)

>> 12:00 19.10.2022
----------------
(kolisin ja haigestusin ka... teavitasin ka meili teel)

----------------
STAGE 2
----------------

>> 13:00 30.10.2022
----------------
Projekti Loomine Valik 2 (eelmine variante läks liiga keeruliseks)
ASP.NET Web Application loomine Microsoft Visual Studio 2019 keskkonnas (steps.txt)

>> 17:00 30.10.2022
----------------
Baas HTML valmidus
Bootstrap lisamine
Bootstrap lehtede loomine ja konfigureerimine

>> 20:00 30.10.2022
----------------
Paus

>> 08:30 31.10.2022
----------------
Bootstrap lehtede funktsionaalsuse lisamine
-dashboard.aspx
-addevent.aspx
-addparticipant.aspx
-participantinfo.aspx
-C# kood

>> 17:30 31.10.2022
----------------
Paus

----------------
STAGE 3
----------------

>> 18:00 31.10.2022
----------------
-Ürituste avalehe vaate kujundamine (dashboard.aspx)
-Moodulite ja liideste kirjutamine
-Funktsionaalsuse lisamine (järgides juhiseid)

>> 21:00 31.10.2022
----------------
Paus

>> 10:00 01.11.2022
----------------
-Muudatuse sisse viimine (vahetasin koodi põhise paneeli populeerimise, asp.net gridview vastu)
-Funktsionaalsuse lisamine (järgides juhiseid)
-Modalite lisamine sujuva kogemuse eesmärgil

>> 17:00 01.11.2022
----------------
Paus

>> 18:00 01.11.2022
----------------
-Osaliste vaate kujundamine (addparticipant.aspx)
-Muutujate edastamise funktsionaalsus (dashboard.aspx --> addparticipant.aspx)
-SQL Käskluste moodustamine
-Osavõtja lisamise funktsionaalsus (SQL käsklused)

>> 19:00 01.11.2022
----------------
-SQL käskluste paigutamine eraldi klassi ja koodi puhastamine

>> 21:00 01.11.2022
----------------
-Osalejate ja ürituste vahelise liidese loomine (prototüüp, peab leidlikult lähenema kuna osalejad saavad osaleda mitmel üritusel jne...)
-Lisa tabeli utiliseerimine(loodetavasti ei tule ID'dega probleeme...)
-Esialgu ainult eraisikud (kuna noh tegelikult saaks neid ju samas tabelis hoiustada... ei teagi kumb see mõistlikum oleks)
-Isikukoodi piirajad jms. tehniline

>> 00:00 02.11.2022
----------------
-Modalitega läks väga keeruliseks... aga kuna need näevad head välja, siis panustan veidi
-Alternatiivide loomine

>> 02:00 02.11.2022
----------------
Paus

>> 08:00 02.11.2022
----------------
-Tabelite vaheline suhtlus läks liiga keeruliseks, otsustasin iga ürituse jaoks oma tabeli teha.
-Iga ürituse jaoks on nüüd enda osalejate tabel
-Osavõtjate lisamine (basic)

>> 12:00 02.11.2022
----------------
-Koodi puhastamine, bugide eemaldamine.
-Kuna kasutan kustutamiseks/eemaldamiseks modalit, siis osavõtjate eemaldamine on hetkel katki (ilu nõuab ohvreid...)

>> 13:00 02.11.2022
----------------
-Koodi hindamine, vigade otsimine.
-Üleliigsete kommentaaride eemaldamine.

>> 13:30 02.11.2022
----------------
-Debugeri lisamine (tuleb kasuks)
-Osavõtjate eemaldamine
-Osavõtja modal värskendab nüüd andmebaasis olevaid andmeid

>> 15.00 02.11.2022
----------------
-Eeldatud funktsionaalsus saavutatud, Ürituste lisamine ja eemaldamine, Osavõtjate lisamine ja eemaldamine üritusele, Andmete muutmine
-Vigade kontrollimine
-Töö piisavas valmiduses, et esitleda olemas olevate puudujääkidega, kuna lahendus viise on erinevaid...

>> 15.20 02.11.2022
----------------
-Dokumentatsiooni koostamine. (kuidas kasutada jne...)

>> 16.20 02.11.2022
----------------
- lõppviimistlus ja upload

----------------
Vead:
- Topelt ID, kui eelnevad sissekanded on kustutatud ("lihtne parandada" SQL poole pealt, kuid ID'ga peaks natuke veel vaeva nägema)
- Sissekande ID tuleb GridView komponendist (parem oleks muudpidi see lahendada, kuid nii toimib hetkel)
- Makse viis seadistamata (dropdown)
- Sissekande tüüp seadistamata, Eraisik/Ettevõte (toggle)
- Osavõtja.Modal läheb kinni kui dropdownis valik teha
- Osalejate arv on seadistamata (kuna vahetasin vahepeal lähenemis viisi)
- Tähemärkide piirang puudub
- Isikukoodi valideerimine puudub (lihtne seadistada, kuid hetkel muud prioriteedid...)
- Hetkel on võimalik lisada osalejaid ka toiminud üritustele (võibolla tulevikus kasulik?)
- Harva juhtub, et ürituste tabeli nimeks satup [Participants_?SQLGetField]. pole hetkel kindel miks... debugeriga seda viga ei esine.
  Debugeri saab sisse lülitada Admin.Master.cs failis, Admin.Debug klassis, isEnabled muutujaga (rida 40)
  Käsklus, mis seda põhjustab on SQLGetField() ja see asub SQLClass.cs failis (rida 182)
  Seda kutsub välja SQLDeleteAtID() ja see asub SQLClass.cs failis (rida 149)
  Seda kutsub välja RemoveFromDatabase() ja see asub Admin.Master.cs failis (rida 95)
  Kahtlustan, et id'ga juhtub vahepeal midagi, viisin mingi paranduse sisse, tundub toimivat, kuid seda viga on korduvalt esinenud!

----------------------------------------------------------------------------------------------------------------
Kasutusjuhend:
1. Eeldusel, et Microsoft SQL Server Management Studio on edukalt paigaldatud, Käivitada SQLQuery_START.sql, et näidis andmed sisestada. (Tühjad üritused)
2. Avada projekt SQL_Test_Project Visual Studio'ga
3. Luua SQL serveriga ühendus (kirjeldatud steps.txt failis)
4. Vajuta F5 või 'run' nuppu
5. Kui veebi rakendus käivitus edukalt, siis edasised juhendid on juba rakenduses kirjas.

----------------------------------------------------------------------------------------------------------------
Kasutatud:
-Bootstrap 5.2.2 (https://getbootstrap.com/docs/5.0/getting-started/download/)
-ASP.NET (dotnet-sdk-6.0.402-win-x64.exe) (https://download.visualstudio.microsoft.com/download/pr/9f4d3331-ff2a-4415-ab5d-eafc9c4f09ee/1922162c9ed35d6c10160f46c26127d6/dotnet-sdk-6.0.402-win-x64.exe)
-Microsoft SQL Server (SQL2019-SSEI-Dev.exe) (https://go.microsoft.com/fwlink/p/?linkid=866662)
-SQL Server Management Studio (SSMS) 18.12.1 (SSMS-Setup-ENU.exe) (https://aka.ms/ssmsfullsetup)
-Visual Studio Community 2019 (16.11.11)
(soovitati küll uusim alla laadida, kuid minu eelnevad tööd on kirjutatud selle versiooniga ning alla laetavat materjali on hetkel oma jagu, ca 10gb. Paraku pole ka virtuaal masina jaoks hetkel aega.
Usun, et töö hindamine sujub tõrgeteta.)
