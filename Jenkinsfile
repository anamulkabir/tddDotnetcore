pipeline {
  agent any
  stages {
    stage ('Code pull'){
        steps{
              checkout scm
        }
    }
    stage('build') {
      steps {
        sh 'dotnet build'
      }
    }
	stage('Run') {
      steps {
        sh 'sudo dotnet run --project AspnetCoreTDD/AspnetCoreTDD.csproj'
      }
    }
    stage('Test build') {
      steps {
        sh 'dotnet test'
      }
    }
  }
}
