const AWS = require('aws-sdk');
var s3 = new AWS.S3({apiVersion: 'v1'});
var UploadtoS3 =  async () => {
    var params = {Bucket: 's3-upload-krishna', Key: 'testkey2', Body: 'testdata'};
let data=await s3.upload(params, function(err, data) {
  if(err){return err;}
  else return data;
});
console.log(data);
};

UploadtoS3();
