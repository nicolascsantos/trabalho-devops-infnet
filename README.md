# trabalho-devops-infnet
Trabalho final da disciplina de DevOps.
API simples para cálculo de juros compostos.

## Script para entrar no EC2 via SSH
```ssh -i .\caminho-arquivo.pem ubuntu@ip-maquina-ec2```

## Script para criar arquivo de serviço
```sudo nano /etc/systemd/system/webapi.service ``` 

## Script para criar serviço
```sudo systemctl enable webapi.service``` 

## Script para reiniciar serviços
```sudo systemctl daemon-reload``` 

## Script para trocar dono de pasta do projeto

 ```chown ubuntu:ubuntu trabalho-devops-infnet/```

 ## Script para instalação do .NET Core no Linux
 sudo apt-get install -y dotnet-sdk-10.0