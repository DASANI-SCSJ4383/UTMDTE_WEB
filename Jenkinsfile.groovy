#!/usr/bin/env groovy

pipeline {
     agent any
     stages {
         stage('Build') {
             steps {
                 echo 'Building...'
                  dir("${WORKSPACE}/scripts") {
                    bat 'D:/Afiq/Subject/SoftwareConstruction/apache-jmeter-5.5/bin/jmeter.bat -n -t D:/Afiq/Subject/SoftwareConstruction/apache-jmeter-5.5/test.jmx -l D:/Afiq/Subject/SoftwareConstruction/apache-jmeter-5.5/report.jtl'
                  }
             }
             post {
                 always {
                     jiraSendBuildInfo branch: 'master', site: 'dasani.atlassian.net'
                 }
             }
         }
         stage('Deploy - Production') {
           when {
               branch 'master'
           }
           steps {
               echo 'Deploying to Production from master...'
           }
           post {
               always {
                   jiraSendDeploymentInfo environmentId: '', environmentName: '', environmentType: 'development', issueKeys: [''], serviceIds: [''], site: 'dasani.atlassian.net', state: 'unknown'
               }
           }
        }
     }
 }
