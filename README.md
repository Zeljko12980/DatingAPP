# README za Web Aplikaciju Turističke Organizacije

Ova web aplikacija omogućava upravljanje turističkim ponudama, rezervacijama i obračunom taksi. U nastavku je detaljan opis funkcionalnosti, uloga korisnika i tehničkih zahtjeva.

---

## **Opis projekta**
Aplikacija je osmišljena za tri vrste korisnika:

1. **Obični korisnici**: Pregledaju turističke ponude, zakazuju putovanja i vrše plaćanja.
2. **Obveznici (Izdavači smještaja)**: Dodaju i upravljaju smještajem te prate takse.
3. **Turistička organizacija (Administratori)**: Upravljaju korisnicima, odobravaju ponude i generišu izvještaje.

---

## **Ključne funkcionalnosti**

### **Za obične korisnike**
- Registracija i prijava.
- Pregled turističkih ponuda sa filtrima (lokacija, cijena, kategorija).
- Zakazivanje putovanja.
- Plaćanje rezervacija putem integrisanih platnih sistema.
- Pregled historije rezervacija.

### **Za obveznike**
- Dodavanje, ažuriranje i brisanje smještajnih ponuda.
- Pregled popunjenosti smještaja.
- Automatski obračun taksi.
- Generisanje izvještaja o prihodima i taksama.

### **Za administratore**
- Upravljanje korisnicima i ulogama.
- Odobravanje i moderacija smještajnih ponuda.
- Generisanje statistika i izvještaja.
- Upravljanje plaćanjima taksi i rezervacijama.

---

## **Tehnički zahtjevi**

- **Frontend**: React.js ili Angular za korisnički interfejs.
- **Backend**: ASP.NET Core za API i poslovnu logiku.
- **Baza podataka**: MySQL ili PostgreSQL za pohranu podataka.
- **Autentifikacija i autorizacija**: JWT za upravljanje sesijama.

---

## **Instalacija i pokretanje**

1. **Preuzimanje projekta**:
   - Klonirajte repozitorij sa GitHub-a: `git clone <link>`

2. **Podešavanje backend-a**:
   - Instalirajte potrebne pakete: `dotnet restore`
   - Konfigurišite konekciju na bazu podataka u `appsettings.json`.
   - Pokrenite aplikaciju: `dotnet run`.

3. **Pokretanje frontend-a**:
   - Instalirajte potrebne pakete: `npm install`
   - Pokrenite razvojni server: `npm start`.

4. **Pristup aplikaciji**:
   - Otvorite browser i idite na `http://localhost:3000` za frontend ili `http://localhost:5000` za backend API.

---

## **Sigurnosne mjere**

- Enkripcija svih osjetljivih podataka.
- Zaštita od SQL injekcija, CSRF i XSS napada.

---

## **Doprinos i razvoj**

1. **Prijedlozi i izmjene**:
   - Otvorite issue na GitHub-u.
2. **Razvojni tim**:
   - Forkujte repozitorij i pošaljite Pull Request.

---

## **Licenca**
Ovaj projekat je licenciran pod MIT licencom.

---

Ako imate dodatnih pitanja, kontaktirajte nas putem email-a: support@tourismapp.com

