# PER IL PROFESSORE
Per funzionare, va aggiunto al database nella tabella Ruoli, nel campo nome:
- Admin
- User
Specificamente scritti in quel modo.

## ADMIN
L'admin NON si può registrare. Va aggiunto manualmente al database nella tabella *"Utenti"*, mettendogli come id nel campo `RuoloId` quello corrispondente all'`id` nella tabella *"Ruoli"*.

## COSA SI PUO' FARE
In questa Web App si può accedere solo dalla Home Page, oppure se si clicca su articoli nella sidebar.
Cosa si può fare?
- login
- registrarsi
  
  come Admin:
 - evadere ordini
 - aggiungere articoli (dal tasto + sulla sidebar)
 - scegliere una data nel sommario degli ordini per far partire due fetch contemporaneamente
   
  come User (e come Admin):
 - aggiungere quantità e articolo all'ordine
 - visionare il carrello
 - svuotare il carrello
 - andare al riepilogo ordine
   
