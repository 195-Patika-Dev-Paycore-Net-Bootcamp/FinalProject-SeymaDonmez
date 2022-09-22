# FinalProject-SeymaDonmez
##  Patika.dev & Paycore .Net Bootcamp Bitirme Projesi

## Proje Hakkında


Bu projede n-tier mimari kullanılmıştır. Projedeki katmanlar şu şekildedir:

![image](https://user-images.githubusercontent.com/77541232/191627828-f7ff60b6-823a-4a25-8afc-cbe761d8ce5b.png)

* PaycoreFinalProject.Base
* PaycoreFinalProject.Data
* PaycoreFinalProject.Dto
* PaycoreFinalProject.Service
* PaycoreFinalProjectAPI
* RabbitMQ.ConsumerConsole
* PaycoreFinalProject.UnitTest


### PaycoreFinalProject.Base
  Bu katman, tüm projede ortak olarak ihtiyaç duyulan özelliklerin ve işlevlerin barındığı katmandır. 

![image](https://user-images.githubusercontent.com/77541232/191629396-d92e9532-b330-4132-b6a8-d06a2cbbdc42.png)

### PaycoreFinalProject.Data

  Data katmanı entitylerimizi modellediğimiz ve veri tabanından veri getirecek repositorylerimizin barındığı katmandır.
  
![image](https://user-images.githubusercontent.com/77541232/191630009-ab3db11c-922c-48b0-90da-bfa12cf28092.png)

### PaycoreFinalProject.Dto
 İstek yapılırken, son kullanıcıya veriyi döndürmek için kullanılırkeni Dto uygulama katmanları arasında veriyi transfer etmek için kullanılır. Veritabanından gelen veriyi kaynak olarak kullanır.
 
![image](https://user-images.githubusercontent.com/77541232/191630057-08932d08-b63a-4b7e-b0d9-41e084b15c5d.png)


### PaycoreFinalProject.Service
 API'dan gelen bilgileri gerekli koşullara göre işleyerek veya denetleyerek data katmanının sağladığı metotları kullanarak veritabanına gönderen aynı şekilde veritabanından da bilgileri alarak gerekli süreçlerden geçirip API katmanına gönderen katmandır.
 
![image](https://user-images.githubusercontent.com/77541232/191630144-11fd8526-dba1-4599-b1de-3fa3e23f67e8.png)

### PaycoreFinalProjectAPI
Kullanıcıyla direkt olarak etkileşimde bulunulan katmandır. Bu katman aracılığıyla kullanıcı tarafından girilen bilgiler alınır. 
  
![image](https://user-images.githubusercontent.com/77541232/191630261-22d1e81b-f800-4845-83de-ef686cd61714.png)


#### Projedeki Model Sınıfları
#### Ürün 
* Ürünlere tam sayı değeri olarak teklif verilebilmektedir.  isOfferable alanına göre ürünlere teklif verilebilir. Kullanıcı ürünü satın alınca,
ilgili ürün datası içerisindeki isSold alanının değeri güncellenmekte ve ürün satışa kaptılmaktadır. 

#### Kategori
* Tüm kategoriler listelenebilmekte ve mevcut olanlar güncellenebilmektedir.

#### Teklif
* Kullanıcılar ürünlere teklif verebilmekte ve ürün fiyatı kadar teklif sunduğunda ürünü satın alabilmektedir. Kullanıcıların ürünlere verdiği teklifler ve ürünlere alınan teklifler listelenebilmektedir.

#### Kullanıcı

* Kullanıcılar sisteme email adresi ve parolaları ile üye olabilir. Kullanıcı parolaları veritabanına şifrelerek saklanmaktadır. Üye olduktan sonra hoşgeldiniz maili gönderilmektedir. Tekrar giriş yapılmak istendiğinde aynı parola ile sisteme giriş yapabilmektedir.  

Veritabanında tabloların ilişkisi aşağıdaki gibidir. 

![image](https://user-images.githubusercontent.com/77541232/191697722-e0fbb497-4117-46ad-85c2-06f7d6c5da7a.png)



## Projedeki Controller'lar

Projede bulunan controller sınıfları aşağıdaki gibidir. 

![image](https://user-images.githubusercontent.com/77541232/191636327-a4c2a91f-2afd-43ae-9566-3e049a59126e.png)

![image](https://user-images.githubusercontent.com/77541232/191636363-b982e3f4-30f9-46fd-a8b9-b3ce575f86a7.png)

![image](https://user-images.githubusercontent.com/77541232/191636383-2b4cc407-ec9a-4929-b6f9-fccc132e7786.png)

![image](https://user-images.githubusercontent.com/77541232/191636417-a22e0e81-ee50-40aa-a6bb-be67d024f331.png)

![image](https://user-images.githubusercontent.com/77541232/191636479-8dd022b9-b067-4ba5-86a8-e80f03774aef.png)



#### Projeyi çalıştırmak için gerekli bilgiler

###### Veri Tabanı Baglantı Ayarları
```json
"AllowedHosts": "*",
   "ConnectionStrings": {
    "PostgreSqlConnection": "User ID=postgres;Password=password;Server=server;Port=5432;Database=PaycoreFinalProjectDb;Integrated Security=true;Pooling=true;timeout=300;"
  }
```

###### E-posta Ayarları
```json
  "MailSettings": {
    "Mail": "E-posta adresiniz",
    "DisplayName": "Görüntülenmesi istenen isim",
    "Password": "Parolanız",
    "Host": "smtp.gmail.com",
    "Port": 587
  }
```
