## Uruchomienie projektu

### Utworzenie nowej sieci 
```
sudo docker network create cluster
```

### Uruchomienie kontenerów działających w nowo utworzonej sieci
```
sudo docker run --name myFirstCluster -d -p 40001:27017 --net cluster mongo mongod --replSet "reply"
sudo docker run --name mySecondCluster -d -p 40002:27017 --net cluster mongo mongod --replSet "reply"
sudo docker run --name myThirdCluster -d -p 40003:27017 --net cluster mongo mongod --replSet "reply"
```

### Połączenie się z jedną repliką, aby uruchomić klienta mongo
```
sudo docker exec -it myFirstCluster mongo
```

### Inicjacja replik
```
settings = {
      "_id" : "reply",
      "members" : [
          {
              "_id" : 0,
              "host" : "myFirstCluster:27017"
          },
          {
              "_id" : 1,
              "host" : "mySecondCluster:27017"
          },
          {
              "_id" : 2,
              "host" : "myThirdCluster:27017"
          }
      ]
  }

rs.initiate(settings)
```

### Zbudowanie aplikacji
``` 
sudo docker build -t funeral-home .
```

### Uruchomienie aplikacji
``` 
sudo docker run --net cluster funeral-home
```
