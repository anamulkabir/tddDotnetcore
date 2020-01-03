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
    stage('Test build') {
      steps {
        sh 'dotnet test'
      }
    }
  }
}
