pipeline {
    agent any // Pode ser substituido por um container Docker com o SDK do .NET, se a infra permitir.

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
    }
}