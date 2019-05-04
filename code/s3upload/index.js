console.log('Loading function');

var AWS = require('aws-sdk');
AWS.config.update({ region: 'us-east-1' });
var s3 = new AWS.S3();

exports.handler = async (event, context, callback) => {
  let encodedImage = event.user_avatar.replace("data:image/jpeg;base64", "");;
  let decodedImage = Buffer.from(encodedImage, 'base64');
  var filePath = new Date().toISOString().slice(0,10) +"/image_"+new Date().toISOString() +".png"
  
  var params = {
    "Body": decodedImage,
    "Bucket": "s3upload-krishna",
    "Key": filePath,
    "ContentType " : "mime/png"
  };
  await s3.upload(params, function (err, data) {
    if (err) {
      callback(err, null);
    } else {
      let response = {
        "statusCode": 200,
        "body": JSON.stringify(data),
        "isBase64Encoded": false
      };
      callback(null, response);
    }
  }).promise();
  return filePath;
};