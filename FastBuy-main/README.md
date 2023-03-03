# Progetto APL "FastBuy" di Saglimbene-Scandura

L'ambiente di installazione e configurazione delle varie componenti utilizzate è Windows 64 bit e Visual Studio 2019.

### Installazione MySQL Command Line e Connettore MySQL C++

<ol>
  <li>Step:
  <ul>
    Installazione MySLQ Web-Community al seguente link:
    <br>
      https://downloads.mysql.com/archives/installer/
      <br>
      Selezionare come Product Version la 8.0.11 e avviare il download.
      <br>
      Terminato il download, lanciare l'installer "mysql-installer-web-community-8.0.11.0.msi".
      <br>
      Click on "yes".
    <li>
      Verrà visualizzata la schermata "MySQL Installer (Adding Community)":
      <br>
      Click on "I accept the license terms" e Click on "next".
    </li>
    <li>
      Verrà visualizzata la schermata "Choosing a Setup Type":
      <br>
      Click on "Custom" (ultimo checkbox) e Click on "next".
    </li>
    <li>
      Verrà visualizzata la schermata "Select Products and Features".
      <br>
      Nella sezione "Available Products" vi saranno 4 prodotti:
      <br>
      Espandere "MySQL Servers" fino a "MySQL Server 8.0.11 - X64" e Click sulla freccetta verde;
      <br>
      il prodotto verrà aggiunto nella sezione a destra "Products/Features To Be Installed".
      <br>
      Espandere "MySQL Connectors", espandere "Connector/C++", espandere "Connector/C++ 1.1":
      <br>
      selezionare "Connector/C++ 1.1.11 - X64" e Click sulla freccetta verde.
      <br>
      Click on "next".
    </li>
    <li>
      Verrà visualizzata la schermata "Installation":
      <br>
      verranno visualizzati:
      <br>
      "Product": "MySQL Server 8.0.11" e "Connector/C++ 1.1.11"
      <br>
      "Status": "Ready to download" (per entrambi i prodotti).
      <br>
      Click on "execute".
      <br>
      Terminati entrambi i download verrà abilitato il bottone "next".
    </li>
    <li>
      Verrà visualizzata la schermata "Product Configuration":
      <br>
      "Product": "MySQL Server 8.0.11"
      <br>
      "Status": "Ready to Configure".
      <br>
      Click on "next".
    </li>
    <li>
      Verrà visualizzata la schermata "Group Replication":
      <br>
      Click on "Standalone MySQL Server / Classic MySQL Replication" e Click on "next".
    </li>
    <li>
      Verrà visualizzata la schermata "Type and Networking":
      <br>
      Selezionare la voce "Config Type" e impostare "Development Computer".
      <br>
      Nessuna altra opzione dovrà essere modificata.
      <br>
      Click on "next".
    </li>
    <li>
      Verrà visualizzata la schermata "Authentication Method":
      <br>
      Click on "Use Strong Password Encryption for Authentication (RECOMMENDED)" e Click on "next".
    </li>
    <li>
      Verrà visualizzata la schermata "Accounts and Roles".
      <br>
      Inserire i seguenti campi:
      <br>
      In "MySQL Root Password": "root"
      <br>
      In "Repeat Password": "root"
      <br>
      Click on "next".
    </li>
    <li>
      Verrà visualizzata la schermata "Windows Service":
      <br>
      Nessuna modifica da apportare e Click on "next".
    </li>
    <li>
      Verrà visualizzata la schermata "Apply Configuration":
      <br>
      Click on "execute".
      <br>
      Quando terminato, verrà abilitato il bottone "finish".
    </li>
    <li>
      Verrà visualizzata la schermata "Installation Complete":
      <br>
      Click on "finish".
    </li>
    <br>
  </ul>
  </li>
  <li>Step:
   <ul>
      Configurazione e inclusione dipendenze in Visual Studio 2019.
     <br>
     Nella barra "Esplora soluzioni" a sinistra, Click Tasto destro su "Modulo_Server_Cpp", subito sotto "Soluzione 'Modulo_Server_Cpp'".
     <br>
     Click on "Proprietà" e espandere "Proprietà di configurazione".
     <br>
     Espandere "C/C++": Click on "General".
     <br>
     Click on "Directory di inclusione aggiuntive": espandere la select e Click on "modifica".
     <br>
     Verrà aperta una nuova finestra.
     <br>
     Sul riquadro in alto, selezionare una riga vuota e inserire il path "C:\Program Files\MySQL\Connector C++ 1.1\include", che corrisponde alla directory di default dove            vengono installati i vari prodotti; in alternativa bisogna specificare il path ..\Connector C++ 1.1\include.
     <br>
     Selezionare un'ulteriore riga vuota subito sotto quella precedentemente inserita e specificare il path "C:\Program Files\MySQL\MySQL Server 8.0\include".
     <br>
     Click on "ok" relativo alla finestra aperta, ovvero "Additional Include Directories". Ciò permetterà di chiudere la finestra precedentemente aperta.
     <br>
     Tornando nell'elenco a sinistra, espandere "Linker" e Click on "General".
     <br>
     A circa metà dell'elenco apparso nel riquadro a destra, selezionare "Directory librerie aggiuntive" e Click on "modifica".
     <br>
     Si aprirà una finestra aggiuntiva, uguale a quella precedentemente vista.
     <br>
     Selezionare nel riquadro in alto una riga vuota e inserire il path "C:\Program Files\MySQL\Connector C++ 1.1\lib\opt".
     <br>
     Selezionare un'ulteriore riga vuota subito sotto quella appena inserita e specificare il path "C:\Program Files\MySQL\MySQL Server 8.0\lib".
     <br>
     Click on "ok" e verrà chiusa tale finestra.
     <br>
     Sempre sotto l'espansione della voce "Linker", nel riquadro a sinistra, Click on "Input".
     <br>
     Sul riquadro a destra, selezionare la prima voce "Dipendenze aggiuntive" e Click on "modifica".
     <br>
     Selezionare una riga vuota e inserire "mysqlcppconn.lib" (non il path ma solo il file).
     <br>
     Selezionare una riga vuota sotto e inserire "libmysql.lib" (non il path ma solo il file).
     <br>
     Click on "ok" e verrà chiusa tale finestra.
     <br>
     A questo punto, verrà visualizzata la finestra delle proprietà aperta inizialmente.
     <br>
     Click on "ok" per terminare il processo di configurazione dell'ambiente Visual Studio 2019.
  </ul>
  </li>
</ol> 

### Installazione Connettore MySQL Python

Per far funzionare correttamente il connettore MySQL in Python, ciò che bisogna fare è installare il file al seguente link:
<br>
https://downloads.mysql.com/archives/c-python/ (la versione utilizzata in questo progetto è la 8.0.27).
<br>
Una volta eseguito il file "mysql-connector-python-8.0.27-windows-x86-64bit.msi", dentro il modulo Python andare ad inserire nei "Percorsi di ricerca", Tasto Destro per selezionare "Aggiungi cartella al percorso di ricerca..." e specificare il path della cartella "MySQL Connector Python 8.0" (di default "C:\Program Files\MySQL").

### Accesso ai Databases mediante MySQL Command Line

Lanciare l'applicazione "MySQL 8.0 Command Line Client".
<br>
Verrà richiesto l'inserimento della password (Enter Password): root.
<br>
Successivamente potranno essere lanciati i comandi per la creazione dei 2 databases, rispettivamente "db_cpp" e "db_python", e l'inserimento dei dati ai fini della simulazione.
<br>
I file da cui estrarre i vari comandi sono posti nella cartella Database.

