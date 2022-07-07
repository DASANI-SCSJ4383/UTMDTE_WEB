pipeline {
     agent any
     stages {
         stage('Build') {
             steps {
                 echo 'Building...'
                  dir("${WORKSPACE}/scripts") {
                    bat 'cd /var/lib/jenkins/apache-jmeter-5.5/bin/jmeter.sh  sh jmeter.sh -Jjmeter.save.saveservice.output_format=xml -n -t /var/lib/jenkins/test.jmx -l /var/lib/jenkins/report.jtl'
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
