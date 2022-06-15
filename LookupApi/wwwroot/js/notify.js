$("document").ready(function() {
   console.log("document loaded successfully")
   
   $("#bind-number").on("click", function() {
      let phoneNumber = $("#phoneNumber").val();
      console.log("Bind number button clicked - " + phoneNumber)
      const payload = {
         phoneNumber
      }
      
      console.info("Payload - ", payload);
      
      $.ajax({
         type: "POST",
         contentType: "application/json",
         url: "/api/notify/bind",
         data: JSON.stringify(payload),
         dataType: "json",
         success: function(data, status, xhr) {
            console.info("Bind successful");
            console.log(data);
         },
         error: function(xhr, status, errorThrown) {
            console.error("Failed to bind. Refer to Twilio logs for more details...")
            console.log(xhr, status, errorThrown)
         }
      });
   })

   $("#notify").on("click", function() {
      const message = $("#message").val()
      console.log(`Message button clicked - ${message}` );

      const payload = {
         identifiers: ["1"],
         message 
      }
      console.info("Payload - ", payload);

      $.ajax({
         type: "POST",
         contentType: "application/json",
         url: "/api/notify/send",
         data: JSON.stringify(payload),
         dataType: "json",
         success: function(data, status, xhr) {
            console.info("Notification request successful");
            console.log(data);
            $("#message").val(`Sample message - ${Date.now()}`)
         },
         error: function(xhr, status, errorThrown) {
            console.error("Failed to bind. Refer to Twilio logs for more details...")
            console.log(xhr, status, errorThrown)
         }
      });
   })
   
});