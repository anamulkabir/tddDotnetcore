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
	stage('publish-testing') {
      steps {
		sh 'sudo systemctl stop aspnetcoretdd.service'
		sh 'sudo dotnet publish ./AspnetCoreTDD/ --output /var/www/aspnetcoretdd --configuration release'
        sh 'sudo systemctl restart aspnetcoretdd.service'
      }
    }
    stage('Test build') {
      steps {
        sh 'dotnet test'
      }
    }
  }
}
