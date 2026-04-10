pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:10.0'
            args '-u root'
        }
    }

    environment {
        AWS_IP = "3.90.147.153"
    }

    stages {
        stage('Checkout') {
            steps {
                echo 'Baixando o código do repositório...'
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                echo 'Restaurando pacotes e dependências do NuGet'
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                echo 'Compilando a aplicação .NET'
                sh 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Test') {
            steps {
                echo 'Executando a suite de testes unitários'
                sh 'dotnet test --configuration Release --no-build --verbosity normal'
            }
        }

        stage('Publish') {
            steps {
                echo 'Empacotando a API para deploy'
                sh 'dotnet publish TrabalhoDevOpsInfnet.API/TrabalhoDevOpsInfnet.API.csproj -c Release -o ./publish-output'
            }
        }

        stage('Deploy to AWS') {
            steps {
                echo 'Iniciando deploy direto para a AWS...'

                sh 'apt-get update && apt-get install -y openssh-client'
                sh 'mkdir -p ~/.ssh && echo "StrictHostKeyChecking no" >> ~/.ssh/config'

                withCredentials([sshUserPrivateKey(credentialsId: 'aws-devops-infnet', keyFileVariable: 'SSH_KEY', usernameVariable: 'SSH_USER')]) {
                    echo 'Transferindo arquivos via SCP...'
                    sh 'scp -i $SSH_KEY -r ./publish-output/* ${SSH_USER}@${AWS_IP}:/var/www/trabalho-devops-infnet/'

                    echo 'Reiniciando os serviços da API...'
                    sh 'ssh -i $SSH-KEY ${SSH_USER}@${AWS_IP} "sudo systemctl restart webapi"'
                }
            }
        }
    }
}